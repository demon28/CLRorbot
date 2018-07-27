using Newtonsoft.Json;

namespace gateio.api.Model
{
    public class MarketInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "no")]
        public int No { get; set; }

        /// <summary>
        /// 币种标识
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// 币种名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "name_en")]
        public string NameEN { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "name_cn")]
        public string NameCN { get; set; }

        /// <summary>
        /// 交易对
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "pair")]
        public string Pair { get; set; }

        /// <summary>
        /// 当前价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// 被兑换货币交易量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "vol_a")]
        public decimal VolA { get; set; }

        /// <summary>
        /// 兑换货币交易量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "vol_b")]
        public decimal VolB { get; set; }

        /// <summary>
        /// 被兑换货币
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "curr_a")]
        public string CurrA { get; set; }

        /// <summary>
        /// 兑换货币
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "curr_b")]
        public string CurrB { get; set; }

        /// <summary>
        /// 货币类型后缀
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "curr_suffix")]
        public string CurrSuffix { get; set; }

        /// <summary>
        /// 涨跌百分百
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "rate_percent")]
        public decimal RatePercent { get; set; }

        /// <summary>
        /// 24小时趋势 up涨 down跌
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "trend")]
        public string Trend { get; set; }
        [JsonProperty(PropertyName = "supply")]

        /// <summary>
        /// 币种供应量
        /// </summary>
        /// <returns></returns>
        public decimal Supply { get; set; }
        [JsonProperty(PropertyName = "marketcap")]

        /// <summary>
        /// 总市值
        /// </summary>
        /// <returns></returns>
        public decimal MarketCap { get; set; }

        /// <summary>
        /// 趋势数据
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "plot")]
        public string Plot { get; set; }
    }
}