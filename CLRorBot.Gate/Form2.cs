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

namespace CLRorBot.Gate
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            OrderReq req = new OrderReq();

            req.CurrencyPair = this.tb_cointype.Text.Trim();
            if (req.CurrencyPair.Contains('/'))
            {
                req.CurrencyPair = req.CurrencyPair.Replace('/', '_');
            }
            req.Amount = decimal.Parse(tb_count.Text);
            req.Rate = decimal.Parse(tb_price.Text);


            string sql = @"insert into  torder_info  ('cointype','count','buyrate','nowrate','amount','status','yingli','profit','remark')
                values ('" + req.CurrencyPair + "','" + req.Amount + "','" + req.Rate + "','0','" + req.Amount * req.Rate + "','0','0','0','')";

          int i=  SQLiteHelper.Instance.ExecuteNonQuery(sql);

            if (i>0)
            {
                MessageBox.Show("添加成功！");
                this.tb_cointype.Text ="0";
                tb_count.Text = "0";
                 tb_price.Text = "0";
            }


        }

      

        private void tb_count_TextChanged(object sender, EventArgs e)
        {
            this.label5.Text =( decimal.Parse(tb_count.Text) * decimal.Parse(tb_price.Text)).ToString();
        }
    }
}
