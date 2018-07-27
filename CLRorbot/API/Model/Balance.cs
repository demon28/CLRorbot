
using System.Collections.Generic;

namespace gateio.api.Model
{
    public class Balance
    {
        /// <summary>
        /// 可用各币种资金余额
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> Available { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// 冻结币种金额
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> Locked { get; set; } = new Dictionary<string, decimal>();
    }
}