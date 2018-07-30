using CLRorbot.Common;
using gateio.api.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            marketlist = marketlist.Skip(2).Take(10).ToList();

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

            SQLiteHelper.ExecuteNonQuery(sql);

        }


        /// <summary>
        /// 查看数据库持有币种
        /// </summary>
        /// <returns></returns>
        private DataTable CheckOrder()
        {
            string sql = @"select * from torder_info where status=0";

            return SQLiteHelper.ExecuteDataSet(sql).Tables[0];

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="where"></param>
        private void DeleteDB(string where)
        {
            string sql = @"delete from torder_info where 1=1";

            if (!string.IsNullOrEmpty(where))
            {
                sql += " and " + where;
            }


            SQLiteHelper.ExecuteNonQuery(sql);

        }



        static bool falg = false;
        object obj = new object();
        /// <summary>
        /// 盈亏监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_monitor_Click(object sender, EventArgs e)
        {
            btn_monitor.Enabled = false;

            await Tick();

            btn_monitor.Enabled = true;
        }


        public void Method()
        {
            Task.Factory.StartNew(async () =>
            {
                await Tick();

            }).ContinueWith((S) =>
            {

                Method();

            });


        }

        public async Task Tick()
        {

            DataTable dataTable = CheckOrder();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                string CurrencyPair = dataTable.Rows[i]["cointype"].ToString();
                var trendinfo = await gateio.api.API.GetTickerAsync(CurrencyPair.Split('_')[0], CurrencyPair.Split('_')[1]);


                decimal nowrate = trendinfo.Last;
                decimal buyrate = decimal.Parse(dataTable.Rows[i]["buyrate"].ToString());
                decimal yingli = nowrate - buyrate;
                decimal uplow = (yingli / buyrate);
                string polfit = (uplow * 100).ToString("f2") + "%";
                decimal count = decimal.Parse(dataTable.Rows[i]["count"].ToString());
                decimal amount = count * nowrate;


                string sql = @"update torder_info  set nowrate='" + nowrate + "',amount='" + amount + "',yingli='" + yingli + "',profit='" + polfit + "'" +
                                "   where cointype='" + CurrencyPair + "'";

                int falg = SQLiteHelper.ExecuteNonQuery(sql);
                Console.WriteLine(falg);


                DataTable dt = CheckOrder();
                this.dataGridView1.DataSource = dt;

                Opear(uplow, count, CurrencyPair, nowrate);



            }

        }

        /// <summary>
        /// 盈亏操作
        /// </summary>
        /// <param name="uplow"></param>
        /// <param name="count"></param>
        /// <param name="CurrencyPair"></param>
        /// <param name="nowrate"></param>
        private async void Opear(decimal uplow, decimal count, string CurrencyPair, decimal nowrate)
        {


            int ying = 5;
                int.TryParse(this.tb_yingli.Text,out ying);

            int kui = -2;
            int.TryParse(this.tb_kuisun.Text,out kui);

            uplow = uplow * 100;

            if (uplow > ying || uplow < kui)  //涨5% 或 跌2% 就抛
            {
                OrderReq req = new OrderReq();
                req.Amount = count;
                req.CurrencyPair = CurrencyPair;
                req.Rate = nowrate;

               await gateio.api.API.SellAsync(req);

                DeleteDB("cointype='" + CurrencyPair+"'");
            }

        }


        private void btn_stopmonitor_Click(object sender, EventArgs e)
        {

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
        }
    }
}
