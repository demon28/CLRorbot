

using System.Collections.Generic;

namespace gateio.api.Model
{

    /// <summary>
    /// 市场深度
    /// </summary>
    public class MarketDeep
    {
        /// <summary>
        /// 卖方深度
        /// </summary>
        /// <returns></returns>
        public List<Deep> Asks { get; set; } = new List<Deep>();

        /// <summary>
        /// 买方深度
        /// </summary>
        /// <returns></returns>
        public List<Deep> Bids { get; set; } = new List<Deep>();
    }


    public class Deep
    {
        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        public decimal Price { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        public decimal Amount { get; set; }
    }
}