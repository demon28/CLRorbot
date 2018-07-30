using Newtonsoft.Json;

namespace gateio.api.Model
{
    public class PairInfo
    {
        /// <summary>
        /// 价格精度
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "decimal_places")]
        public int DecimalPlaces { get; set; }


        /// <summary>
        /// 最小下单量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "min_amount")]
        public decimal MinAmount { get; set; }

        /// <summary>
        /// 交易费
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "fee")]
        public decimal Fee { get; set; }
    }
}