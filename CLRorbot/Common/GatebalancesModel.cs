using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CLRorbot.Common
{
   public class GatebalancesModel
    {
        public bool result { get; set; }
        public Dictionary<string, decimal> available;
        public Dictionary<string, decimal> locked;
    }
}
