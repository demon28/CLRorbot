using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRorbot.Common
{

    public class GateMarketModel
    {
        public bool result { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public int no { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string name_en { get; set; }
        public string name_cn { get; set; }
        public string pair { get; set; }
        public decimal rate { get; set; }
        public decimal vol_a { get; set; }
        public decimal vol_b { get; set; }
        public string curr_a { get; set; }
        public string curr_b { get; set; }
        public string curr_suffix { get; set; }
        public decimal rate_percent { get; set; }
        public string trend { get; set; }
        public decimal supply { get; set; }
        public string marketcap { get; set; }
        public object plot { get; set; }
    }


}
