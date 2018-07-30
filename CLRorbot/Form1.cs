using CLRorbot.Common;
using gateio.api.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Common;

namespace CLRorbot
{
    public partial class Form1 : Form
    {

        string apiKey = "2D359374-04C8-4A74-8019-04A7455146F8";
        string SecretKey = "bf0eb403c0f02ebd7ab15980d9cb6d400fa00dae180d90ce5c3817687ea3ee5d";

        GateAPIFacade gate;
        static List<Datum> top10;
        StringBuilder builder = new StringBuilder();
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
            gate = new GateAPIFacade(apiKey, SecretKey);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.tb_apikey.Text = apiKey;
            this.tb_seckey.Text = SecretKey;
            gateio.api.API.SetKey(apiKey, SecretKey);

            GetBlanceAsync();
        }



        private async void btn_star_Click(object sender, EventArgs e)
        {
            //this.timer1.Interval = 1000 * 60 * 60 * int.Parse(this.tb_zhongzhi.Text); //每8小时执行一次 清空所有盘面,不论涨跌
            //this.timer1.Start();

            await ClearDealAsync();


        }
        /// <summary>
        /// 查询余额
        /// </summary>
        private async void GetBlanceAsync()
        {
            var blance = await gateio.api.API.GetBalancesAsync();



            foreach (var item in blance.Available)
            {
                builder.AppendLine("余额：" + item.Key + "----:" + item.Value);
            }

            foreach (var item in blance.Locked)
            {
                builder.AppendLine("挂单：" + item.Key + "----:" + item.Value);
            }
            builder.AppendLine("===============================================");

            this.textBox1.Text = builder.ToString();


        }


        public List<Datum> GetTop10()
        {
            GateMarketModel model = gate.MarketList();

            if (!model.result)
            {
                return new List<Datum>();
            }
            List<Datum> data = model.data.OrderByDescending(S => S.rate_percent).ToList();
            data = data.Where(S => S.pair.Contains("_usdt")).ToList();  //排除非usdt交易对
            data = data.Skip(2).ToList();
            data = data.Take(10).ToList(); //拿前面10条
            top10 = data;
            return data;
        }


        private void btn_end_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer2.Stop();
            ClearLog();
        }




        private async void timer2_Tick(object sender, EventArgs e)
        {

            TakeDeal();
        }


        private async void timer1_Tick(object sender, EventArgs e)
        {
            await ClearDealAsync();
        }

        /// <summary>
        /// 清除所有挂单，然后重新查询前十买入
        ///step1:查询是否有持有的币，有的全部抛成usdt
       ///step2：获取前1，去掉前2（风险），买入
        /// </summary>
        /// <returns></returns>
        public async Task ClearDealAsync()
        {



            #region 先卖掉盘面所有币种，有深度问题后续处理

            await QingPanAsync();


            #endregion



            #region 买入Top10币种

            await MaiPan();


            #endregion

        }


        /// <summary>
        /// 清空所有持有币种
        /// </summary>
        /// <returns></returns>
        public async Task QingPanAsync()
        {

            var blance = await gateio.api.API.GetBalancesAsync();
            blance.Available.Remove("USDT");
            if (blance.Available.Count != 0)
            {
                foreach (var item in blance.Available)
                {

                    var model = await GetCoinPriceAsync(item.Key);
                    decimal price = model.HighestBid; //拿到买方最高价
                    if (price*item.Value<1)
                    {
                        continue;
                    }


                    OrderReq orderReqSell = new OrderReq();
                    orderReqSell.Amount = item.Value;
                    orderReqSell.Rate = price;
                    orderReqSell.CurrencyPair = item.Key + "_usdt";

                    await SellAsync(orderReqSell);

                }
            }

        }

        /// <summary>
        /// 买入前十币种
        /// </summary>
        /// <returns></returns>
        public async Task MaiPan()
        {
            List<Datum> top10data = GetTop10();

            var blancelist = await gateio.api.API.GetBalancesAsync();
            decimal usdtcount = blancelist.Available["USDT"];

            foreach (var item in top10data)
            {

                OrderReq orderReqbuy = new OrderReq();


                var coinmodel = await GetCoinPriceAsync(item.curr_a);

                decimal usdt = usdtcount / 10;    //十分之一的资金

                decimal amount = decimal.Parse(Math.Floor(Convert.ToDouble(usdt / coinmodel.LowestAsk)).ToString()); //能买多少个
                if (amount<=0)
                {
                    continue;
                }
                orderReqbuy.Amount = amount;
                orderReqbuy.CurrencyPair = item.curr_a.ToLower() + "_" + item.curr_b.ToLower();
                orderReqbuy.Rate = coinmodel.LowestAsk;

                await BuyAsync(orderReqbuy);
            }


        }





        /// <summary>
        /// 每分钟查看持有币种，计算涨跌值，然后抛掉
        /// </summary>
        private void TakeDeal()
        {
            GetUpLow();


        }

        private async void GetUpLow()
        {
            var marketlist = await gateio.api.API.GetMarketListAsync();
            marketlist = marketlist.Where(S => S.CurrB == "USDT").ToList();

            for (int i = 0; i <table.Rows.Count; i++)
            {
                foreach (var item in marketlist)
                {
                    if (table.Rows[i]["CoinType"].ToString()==item.CurrA)
                    {

                        decimal nowamount= decimal.Parse(table.Rows[i]["Count"].ToString()) * item.Rate;
                        decimal yingli = nowamount - decimal.Parse(table.Rows[i]["Amount"].ToString());
                        decimal uplow= yingli/ decimal.Parse(table.Rows[i]["Amount"].ToString());

                        table.Rows[i]["NowAmount"] = nowamount;
                        table.Rows[i]["Yingli"] = yingli;
                        table.Rows[i]["Up_Low"] = uplow.ToString("f2")+"%";

                    }


                }

            }

            this.dataGridView1.DataSource = table;

        }





        /// <summary>
        /// 获取单个币价
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        public async Task<TradeInfo> GetCoinPriceAsync(string coin)
        {
            var res = await gateio.api.API.GetTickerAsync(coin.ToLower(), "usdt");

            return res;
        }

        /// <summary>
        /// 买入
        /// </summary>
        /// <param name="orderReq"></param>
        /// <returns></returns>
        public async Task BuyAsync(OrderReq orderReq)
        {

   


            alert(orderReq.CurrencyPair + "======Buy:" + orderReq.Rate + "=====amount:" + orderReq.Amount);

            var res = await gateio.api.API.BuyAsync(orderReq);

     


        }
        /// <summary>
        /// 卖出
        /// </summary>
        /// <param name="orderReq"></param>
        /// <returns></returns>
        public async Task SellAsync(OrderReq orderReq)
        {

            //string sql = @"insert into torder_info('jiaoyidui','buyprice','sellprice','yinkuibi','amount','status')  
            //            values('" + orderReq.CurrencyPair + "','0','" + orderReq.Rate + "','0','"+orderReq.Amount+"','1')  ;";

            //SQLiteHelper.ExecuteNonQuery(sql);


            alert(orderReq.CurrencyPair + "======Sell:" + orderReq.Rate + "=====amount:" + orderReq.Amount);

            var res = await gateio.api.API.SellAsync(orderReq);

        }







        private void Form1_Shown(object sender, EventArgs e)
        {
            //Form2 form = new Form2();
            //form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 f = new Form2();
            f.Show();
        }

        public void ClearLog()
        {
            builder.Clear();
            this.textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        public  void alert(string val)
        {
            builder.AppendLine(val);
            this.textBox1.Text = builder.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.timer2.Interval = 1000 * int.Parse(this.tb_jiankong.Text); //每分钟监控，达到盈亏就操作
            this.timer2.Start();

            BasePrice();
        }






        private async void BasePrice()
        {
            //获取24小时成功信息

            var blance = await gateio.api.API.GetBalancesAsync();
            blance.Available.Remove("USDT");

            var marketlist = await gateio.api.API.GetMarketListAsync();
            marketlist = marketlist.Where(S => S.CurrB == "USDT").ToList();

           
            table.Columns.Add("CoinType", Type.GetType("System.String"));
            table.Columns.Add("Count", Type.GetType("System.String"));
            table.Columns.Add("Amount", Type.GetType("System.String"));
            table.Columns.Add("Yingli", Type.GetType("System.String"));
            table.Columns.Add("NowAmount", Type.GetType("System.String"));
            table.Columns.Add("Up_Low", Type.GetType("System.String"));

            foreach (var item in blance.Available)
            {
                
                
                foreach (var market in marketlist)
                {


                    if (market.CurrA==item.Key)
                    {
                        DataRow rows = table.NewRow();
                        rows["CoinType"] = market.CurrA;
                        rows["Count"] = item.Value;
                        rows["Amount"] = item.Value* market.Rate;
                        rows["Yingli"] = "0";
                        rows["NowAmount"] = item.Value * market.Rate;
                        rows["Up_Low"] = "0%";

                        table.Rows.Add(rows);
                    }
                   
                }
            }
            this.dataGridView1.DataSource = table;

        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            //string sql = @"insert into torder_info('jiaoyidui','buyprice','sellprice','yinkuibi','amount','status') 
            //            values('" + orderReq.CurrencyPair + "','" + orderReq.Rate + "','0','0','" + orderReq.Amount + "','0')  ;";
            //SQLiteHelper.ExecuteNonQuery(sql);


            //string sql = @"insert into torder_info ('jiaoyidui','buyprice','sellprice','yinkuibi','amount','status') 
            //            values ('btc_usdt','80','0','0','70','0')  ;";
            //SQLiteHelper.ExecuteNonQuery(sql);

            MyTradeHistoryReq req = new MyTradeHistoryReq();
            req.CurrencyPair = "GLC_USDT";
            req.OrderNo = "";
            var res = await gateio.api.API.MyTradeHistoryAsync(req);


            alert(res[0].Pair);
        }
    }
}
