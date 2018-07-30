using Newtonsoft.Json;

namespace gateio.api.Model
{


    public class OrderReq
    {
        /// <summary>
        /// 交易币种对(如ltc_btc,ltc_btc)
        /// </summary>
        /// <returns></returns>
        public string CurrencyPair { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        public decimal Rate { get; set; }

        /// <summary>
        /// 交易量
        /// </summary>
        /// <returns></returns>
        public decimal Amount { get; set; }
    }


    public class CancelOrderReq
    {
        /// <summary>
        /// 下单单号
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 交易币种对(如 ltc_btc)
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "currencyPair")]
        public string CurrencyPair { get; set; }
    }


    public class CancelAllOrdersReq
    {
        /// <summary>
        /// 下单类型 必填
        /// </summary>
        /// <returns></returns>
        public TradeType Type { get; set; }

        /// <summary>
        /// 交易对 必填
        /// </summary>
        /// <returns></returns>
        public string CurrencyPair { get; set; }
    }

    public enum TradeType
    {
        /// <summary>
        /// 不限
        /// </summary>
        Unlimited = -1,
        /// <summary>
        /// 卖出
        /// </summary>
        Sell = 0,
        /// <summary>
        /// 买入
        /// </summary>
        Buy = 1
    }


    public class GetOrderReq
    {
        public string OrderNo { get; set; }

        public string CurrencyPair { get; set; }
    }


    public class GetOrderRes
    {
        /// <summary>
        /// 订单号
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// 交易对
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "currencyPair")]
        public string CurrencyPair { get; set; }

        /// <summary>
        /// 买卖类型 sell 卖出， buy 买入
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// 买卖数量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 下单价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "initialRate")]
        public decimal InitialRate { get; set; }

        /// <summary>
        /// 下单量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "initialAmount")]
        public decimal InitialAmount { get; set; }


        /// <summary>
        /// 成交价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "filledRate")]
        public decimal FilledRate { get; set; }

        /// <summary>
        /// 成交数量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "filledAmount")]
        public decimal FilledAmount { get; set; }

        /// <summary>
        /// 费率
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "feePercentage")]
        public decimal FeePercentage { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "feeValue")]
        public decimal FeeValue { get; set; }

        [JsonProperty(PropertyName = "feeCurrency")]
        public string FeeCurrency { get; set; }


        [JsonProperty(PropertyName = "fee")]
        public string Fee { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }
    }


    public class OpenOrderRes
    {
        /// <summary>
        /// 订单号
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "orderNumber")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 买卖类型 buy 买入,sell 卖出
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 交易单价
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// 订单总数量 剩余未成交数量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 总计
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "total")]
        public decimal Total { get; set; }

        /// <summary>
        /// 下单价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "initialRate")]
        public decimal InitialRate { get; set; }

        /// <summary>
        /// 下单量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "initialAmount")]
        public decimal InitialAmount { get; set; }

        /// <summary>
        /// 成交价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "filledRate")]
        public decimal FilledRate { get; set; }

        /// <summary>
        /// 已成交量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "filledAmount")]
        public decimal FilledAmount { get; set; }

        /// <summary>
        /// 交易对
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "currencyPair")]
        public string CurrencyPair { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}