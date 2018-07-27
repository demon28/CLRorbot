using CLRorbot.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLRorbot
{
    public partial class Form2 : Form
    {
        string apiKey = "2D359374-04C8-4A74-8019-04A7455146F8";
        string SecretKey = "bf0eb403c0f02ebd7ab15980d9cb6d400fa00dae180d90ce5c3817687ea3ee5d";

        GateAPIFacade gate;
        static List<Datum> top15;


        public Form2()
        {
          
            InitializeComponent();

            gate = new GateAPIFacade(apiKey, SecretKey);
            this.timer1.Interval = 1000 * 60;
            this.timer1.Start();
            this.dataGridView1.DataSource = BindList();
   
        }

        private DataTable BindList()
        {
            DataTable dt = new DataTable();
            dt = ListToDatatableHelper.ToDataTable(GetTop15());
            dt.Columns.Remove("name_en");
            dt.Columns.Remove("curr_a");
            dt.Columns.Remove("curr_b");
            dt.Columns.Remove("curr_suffix");
            dt.Columns.Remove("supply");
            dt.Columns.Remove("name");
            dt.Columns.Remove("plot");



            dt.Columns["symbol"].ColumnName = "标识";
            dt.Columns["pair"].ColumnName = "交易对";
            dt.Columns["rate"].ColumnName = "当前价格";
            dt.Columns["vol_a"].ColumnName = "被兑换交易量";
            dt.Columns["vol_b"].ColumnName = "兑换交易量";
            dt.Columns["rate_percent"].ColumnName = "涨跌";
            dt.Columns["trend"].ColumnName = "24小时趋势";
            dt.Columns["marketcap"].ColumnName = "总市值";

            return dt;
        }
        public List<Datum> GetTop15()
        {
            GateMarketModel model = gate.MarketList();

            if (!model.result)
            {
                return new List<Datum>();
            }
            List<Datum> data = model.data.OrderByDescending(S => S.rate_percent).ToList();
            data = data.Where(S => S.pair.Contains("_usdt")).ToList();  //排除非usdt交易对
            data = data.Take(15).ToList(); //拿前面15条
            top15 = data;
            return data;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = BindList();
        }
    }
}
