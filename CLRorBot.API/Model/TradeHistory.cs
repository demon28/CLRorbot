
using System;
using Newtonsoft.Json;

namespace gateio.api.Model
{
    public class TradeHistory
    {
        /// <summary>
        /// 交易ID
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "tradeID")]
        public int TradeID { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// 买卖类型 buy 买 sell 卖
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 币种单价
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// 成交币种数量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 订单总额
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "total")]
        public decimal Total { get; set; }

    }



    public class MyTradeHistoryReq
    {
        /// <summary>
        /// 交易对 必填
        /// </summary>
        /// <returns></returns>
        public string CurrencyPair { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        /// <returns></returns>
        public string OrderNo { get; set; }
    }

    public class MyTradeHistory
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 订单id
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "orderid")]
        public int OrderId { get; set; }

        /// <summary>
        /// 交易对
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "pair")]
        public string Pair { get; set; }

        /// <summary>
        /// 买卖类型
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 买卖价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// 订单买卖币种数量
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "time_unix")]
        public long Timestamp { get; set; }
    }
}