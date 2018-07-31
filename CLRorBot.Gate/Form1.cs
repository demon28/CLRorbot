using CLRorbot.Common;
using gateio.api.Model;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Common;

namespace CLRorBot.Gate
{
    public partial class Form1 : Form
    {
        string apiKey = "2D359374-04C8-4A74-8019-04A7455146F8";
        string SecretKey = "bf0eb403c0f02ebd7ab15980d9cb6d400fa00dae180d90ce5c3817687ea3ee5d";
        List<MarketInfo> marketlist = new List<MarketInfo>();

        public Form1()
        {

            InitializeComponent();

            gateio.api.API.SetKey(apiKey, SecretKey);

            isoperate = this.checkBox1.Checked;

        }




        private async void btn_top15_ClickAsync(object sender, EventArgs e)
        {
            await GetTop();
        }


        public async Task GetTop()
        {

            marketlist = await gateio.api.API.GetMarketListAsync();
            marketlist = marketlist.Where(S => S.CurrB == "USDT").Where(S => S.Trend == "up").OrderByDescending(S => S.RatePercent).ThenBy(S => S.VolB).ToList();

            var dellist = marketlist.ToList();
            foreach (var item in dellist)
            {
                if (item.VolA < 100)
                {
                    marketlist.Remove(item);
                }

            }


            DataTable dt = new DataTable();
            dt = ListToDatatableHelper.ToDataTable(marketlist);

            dt.Columns.Remove("No");
            dt.Columns.Remove("NameEN");
            dt.Columns.Remove("CurrA");
            dt.Columns.Remove("CurrB");
            dt.Columns.Remove("CurrSuffix");
            dt.Columns.Remove("Supply");
            dt.Columns.Remove("Name");
            dt.Columns.Remove("Plot");


            dt.Columns["symbol"].ColumnName = "标识";
            dt.Columns["Pair"].ColumnName = "交易对";
            dt.Columns["Rate"].ColumnName = "当前价格";
            dt.Columns["VolA"].ColumnName = "被兑换交易量";
            dt.Columns["VolB"].ColumnName = "兑换交易量";
            dt.Columns["RatePercent"].ColumnName = "涨跌";
            dt.Columns["Trend"].ColumnName = "24小时趋势";
            dt.Columns["MarketCap"].ColumnName = "总市值";

            this.dataGridView1.DataSource = dt;
        }

        private async void btn_user_Click(object sender, EventArgs e)
        {
            var user = await gateio.api.API.GetBalancesAsync();
            DataTable dt = new DataTable();
            dt = ListToDatatableHelper.DicToTable(user.Available);

            this.dataGridView1.DataSource = dt;
        }

        private async void btn_sellAll_Click(object sender, EventArgs e)
        {
            this.btn_sellAll.Enabled = false;

            await SellAll();

            this.btn_sellAll.Enabled = true;
            await QueryOrder();
        }

        private async void btn_buyAll_Click(object sender, EventArgs e)
        {

            this.btn_buy.Enabled = false;

            await BuyAll();


            this.btn_buy.Enabled = true;

            await QueryOrder();
        }


        private async void btn_clearorder_Click(object sender, EventArgs e)
        {
            this.btn_clearorder.Enabled = false;
            await CancelAllOrder();
            this.btn_clearorder.Enabled = true;
        }

        private void btn_checkcoin_Click(object sender, EventArgs e)
        {
            btn_checkcoin.Enabled = false;
            this.dataGridView1.DataSource = CheckOrder();
            btn_checkcoin.Enabled = true;
        }


        /// <summary>
        /// 一键卖币
        /// </summary>
        private async Task SellAll()
        {
            var blance = await gateio.api.API.GetBalancesAsync();
            blance.Available.Remove("USDT");


            if (blance.Available.Count != 0)
            {
                foreach (var item in blance.Available)
                {

                    var model = await gateio.api.API.GetTickerAsync(item.Key, "usdt");

                    decimal price = model.HighestBid; //拿到买方最高价

                    if (price * item.Value < 1)    //小余1美金的残余币则不操作
                    {
                        continue;
                    }


                    OrderReq orderReqSell = new OrderReq();
                    orderReqSell.Amount = item.Value;
                    orderReqSell.Rate = price;
                    orderReqSell.CurrencyPair = item.Key + "_usdt";

                    await gateio.api.API.SellAsync(orderReqSell);



                    DeleteDB(null);
                }
            }
        }



        /// <summary>
        /// 一键买币
        /// </summary>
        /// <returns></returns>
        private async Task BuyAll()
        {
            var blancelist = await gateio.api.API.GetBalancesAsync();
            decimal usdtcount = blancelist.Available["USDT"];

            if (marketlist.Count == 0)
            {
                await GetTop();
            }

            int coincount = 5;
            int.TryParse(this.tb_coincount.Text, out coincount);

            marketlist = marketlist.Skip(2).Take(coincount).ToList();

            foreach (var item in marketlist)
            {

                OrderReq orderReqbuy = new OrderReq();


                var coinmodel = await gateio.api.API.GetTickerAsync(item.CurrA, "usdt");

                decimal usdt = usdtcount / 10;    //十分之一的资金

                decimal amount = decimal.Parse(Math.Floor(Convert.ToDouble(usdt / coinmodel.LowestAsk)).ToString()); //能买多少个
                if (amount <= 0 || usdt <= 1)
                {
                    continue;
                }
                orderReqbuy.Amount = amount;
                orderReqbuy.CurrencyPair = item.CurrA.ToLower() + "_" + item.CurrB.ToLower();
                orderReqbuy.Rate = coinmodel.LowestAsk;

                string res = await gateio.api.API.BuyAsync(orderReqbuy);


                InsertDataBase(orderReqbuy, res);
            }
        }


        /// <summary>
        /// 取消所有挂单
        /// </summary>
        /// <returns></returns>
        private async Task CancelAllOrder()
        {
            var orderlist = await gateio.api.API.OpenOrdersAsync();

            foreach (var item in orderlist)
            {
                CancelAllOrdersReq req = new CancelAllOrdersReq();
                req.CurrencyPair = item.CurrencyPair;
                req.Type = TradeType.Unlimited;

                await gateio.api.API.CancelAllOrdersAsync(req);

            }

        }



        /// <summary>
        /// 插入数据库
        /// </summary>
        /// <param name="req"></param>
        /// <param name="res"></param>
        /// <param name="price"></param>
        private void InsertDataBase(OrderReq req, string res)
        {
            string sql = @"insert into  torder_info  ('cointype','count','buyrate','nowrate','amount','status','yingli','profit','remark')
                values ('" + req.CurrencyPair + "','" + req.Amount + "','" + req.Rate + "','0','" + req.Amount * req.Rate + "','0','0','0','" + res + "')";

            SQLiteHelper.Instance.ExecuteNonQuery(sql);

        }


        /// <summary>
        /// 查看数据库持有币种
        /// </summary>
        /// <returns></returns>
        private DataTable CheckOrder()
        {
            string sql = @"select * from torder_info where status=0";

            return SQLiteHelper.Instance.ExecuteDataSet(sql).Tables[0];

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="where"></param>
        private static void  DeleteDB(string where)
        {
            string sql = @"delete from torder_info where 1=1";

            if (!string.IsNullOrEmpty(where))
            {
                sql += " and " + where;
            }


            SQLiteHelper.Instance.ExecuteNonQuery(sql);

        }



        static bool falg = false;
        object obj = new object();
        /// <summary>
        /// 盈亏监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_monitor_Click(object sender, EventArgs e)
        {
            btn_monitor.Enabled = false;

            falg = true;

            Task.Factory.StartNew(() =>
           {
               while (falg)
               {
                   Tick(this);
                   System.Threading.Thread.Sleep(1000);
               }
           });


            btn_monitor.Enabled = true;
        }


      

        public void Tick(Form form)
        {

            DataTable dataTable = CheckOrder();
            List<Task> allTask = new List<Task>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                System.IO.File.AppendAllText("d:\\clrobot.txt", $"{DateTime.Now.ToString()}\tThreadId={System.Threading.Thread.CurrentThread.ManagedThreadId},current index={i}{Environment.NewLine}");
                DataRow row = dataTable.Rows[i];
                allTask.Add(
                Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        await GetApiData(row, form);
                        DataTable dt = CheckOrder();
                        form.Invoke((MethodInvoker)delegate ()
                        {
                            this.dataGridView1.DataSource = dt;
                        });
                    }
                    catch (Exception ex)
                    {
                    }
                }));

               


            }
            Task.WaitAll(allTask.ToArray());

        }

        /// <summary>
        /// 异步调取API并修改数据库
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static async Task GetApiData(DataRow row, Form form)
        {
            string CurrencyPair = row["cointype"].ToString();
            var trendinfo = await gateio.api.API.GetTickerAsync(CurrencyPair.Split('_')[0], CurrencyPair.Split('_')[1]);
            decimal nowrate = trendinfo.Last;
            decimal buyrate = decimal.Parse(row["buyrate"].ToString());
            decimal yingli = nowrate - buyrate;
            decimal uplow = (yingli / buyrate);
            string polfit = (uplow * 100).ToString("f2") + "%";
            decimal count = decimal.Parse(row["count"].ToString());
            decimal amount = count * nowrate;


            string sql = @"update torder_info  set nowrate='" + nowrate + "',amount='" + amount + "',yingli='" + yingli + "',profit='" + polfit + "'" +
                            "   where cointype='" + CurrencyPair + "'";

            int res = SQLiteHelper.Instance.ExecuteNonQuery(sql);

            if (isoperate)
            {
                Opear(uplow, count, CurrencyPair, nowrate,form);
            }


        }

        /// <summary>
        /// 盈亏操作
        /// </summary>
        /// <param name="uplow"></param>
        /// <param name="count"></param>
        /// <param name="CurrencyPair"></param>
        /// <param name="nowrate"></param>
        private async static void Opear(decimal uplow, decimal count, string CurrencyPair, decimal nowrate, Form form)
        {


            TextBox strying = form.Controls.Find("tb_yingli", true)[0] as TextBox;
            TextBox strkui = form.Controls.Find("tb_kuisun", true)[0] as TextBox;


            int ying = 5;
            int.TryParse(strying.Text, out ying);

            int kui = -2;
            int.TryParse(strkui.Text, out kui);

            uplow = uplow * 100;

            if (uplow > ying || uplow < kui)  //涨5% 或 跌2% 就抛
            {
                OrderReq req = new OrderReq();
                req.Amount = count;
                req.CurrencyPair = CurrencyPair;
                req.Rate = nowrate;

                if (req.Amount* req.Rate<1)
                {
                    return;
                }

                await gateio.api.API.SellAsync(req);

                DeleteDB("cointype='" + CurrencyPair + "'");
            }

        }


        private void btn_stopmonitor_Click(object sender, EventArgs e)
        {
            falg = false;
        }

        private async void btn_queryorder_Click(object sender, EventArgs e)
        {

            this.btn_queryorder.Enabled = false;
            await QueryOrder();

            this.btn_queryorder.Enabled = true;
        }

        /// <summary>
        /// 查看当前挂单信息
        /// </summary>
        /// <returns></returns>
        private async Task QueryOrder()
        {
            var orderlist = await gateio.api.API.OpenOrdersAsync();

            DataTable dt = ListToDatatableHelper.ToDataTable(orderlist);

            this.dataGridView1.DataSource = dt;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void btn_delall_Click(object sender, EventArgs e)
        {
            DeleteDB(null);
            this.dataGridView1.DataSource = CheckOrder();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btn_pipei_Click(object sender, EventArgs e)
        {


            this.btn_pipei.Enabled = false;
            DeleteDB(null);
            PiPei();
            this.btn_pipei.Enabled = true;
        }

        /// <summary>
        /// 匹配数据库
        /// </summary>
        private async void PiPei()
        {

            var blance = await gateio.api.API.GetBalancesAsync();
            blance.Available.Remove("USDT");   //去除usdt
            var blancelist = blance.Available.Where(S => S.Value > 0.01m).ToList();  //去除小余0.01的币种

            foreach (var item in blancelist)
            {
                MyTradeHistoryReq req = new MyTradeHistoryReq();
                req.CurrencyPair = item.Key + "_USDT";

                var order = await gateio.api.API.MyTradeHistoryAsync(req);

                order = order.Where(S => S.Type == "buy").ToList();  //只看买的

                order = order.Where(S => S.Rate * item.Value > 1).ToList(); // 去除金额小于1usdt的币种

                if (order.Count == 0)
                {
                    continue;
                }

                OrderReq model = new OrderReq();
                
                //如果只有一条直接插入
                if (order.Count == 1)
                {
                    model.Amount = order[0].Amount;
                    model.Rate = order[0].Rate;

                    if (model.Amount != item.Value)
                    {
                        model.Amount = item.Value;
                    }
                    model.CurrencyPair = req.CurrencyPair;
                    InsertDataBase(model, string.Empty);

                    continue;
                }



                decimal count = order.Sum(S => S.Amount);

                decimal total = order.Sum(S => S.Rate * S.Amount);


                model.Amount = count;
                if (model.Amount != item.Value)
                {
                    model.Amount = item.Value;
                }
                model.Rate = total / count;
                model.CurrencyPair = req.CurrencyPair;

                InsertDataBase(model, string.Empty);
            }


            this.dataGridView1.DataSource = CheckOrder();

        }

        private void btn_timer_Click(object sender, EventArgs e)
        {



        }


        static bool isoperate = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            isoperate = this.checkBox1.Checked;

        }
    }




}
