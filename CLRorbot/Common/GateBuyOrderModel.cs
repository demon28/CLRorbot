using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRorbot.Common
{




    public class GateBuyOrderModel
    {
        public string result { get; set; }
        public string orderNumber { get; set; }
        public string rate { get; set; }
        public string leftAmount { get; set; }
        public string filledAmount { get; set; }
        public string filledRate { get; set; }
        public string message { get; set; }
    }

  
}
