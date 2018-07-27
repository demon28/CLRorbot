
using Newtonsoft.Json;

namespace gateio.api.Model
{
    public class TradeInfo
    {
        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "baseVolume")]
        public decimal BaseVolume { get; set; }

        [JsonProperty(PropertyName = "high24hr")]
        public decimal High24HR { get; set; }

        [JsonProperty(PropertyName = "highestBid")]
        public decimal HighestBid { get; set; }

        [JsonProperty(PropertyName = "last")]
        public decimal Last { get; set; }

        [JsonProperty(PropertyName = "low24hr")]
        public decimal Low24HR { get; set; }

        [JsonProperty(PropertyName = "lowestAsk")]
        public decimal LowestAsk { get; set; }

        [JsonProperty(PropertyName = "percentChange")]
        public decimal PercentChange { get; set; }

        [JsonProperty(PropertyName = "quoteVolume")]
        public decimal QuoteVolume { get; set; }

    }
}