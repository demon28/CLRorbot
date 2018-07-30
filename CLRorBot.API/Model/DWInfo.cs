using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace gateio.api.Model
{


    public class DWHistory
    {
        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        public List<DWInfo> Deposits { get; set; } = new List<DWInfo>();

        /// <summary>
        /// 提现
        /// </summary>
        /// <returns></returns>
        public List<DWInfo> Withdraws { get; set; } = new List<DWInfo>();
    }

    /// <summary>
    /// 充值/提现
    /// </summary>
    public class DWInfo
    {
        /// <summary>
        /// 交易Id
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 充值/提现地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// txid
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "txid")]
        public string TXId { get; set; }

        /// <summary>
        /// 发起时间戳
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        [JsonIgnore]
        public DateTime Date
        {
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(Timestamp).ToLocalTime().DateTime;
            }
        }

        /// <summary>
        /// 记录状态 DONE 完成 CANCEL 取消 REQUEST 请求中
        /// </summary>
        /// <returns></returns>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}