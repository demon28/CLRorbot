using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using gateio.api.Model;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.Text;

namespace gateio.api
{
    public class API
    {
        private static readonly HttpClient _httpClient = new HttpClient();


        static API()
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        public static void SetKey(string key, string secret)
        {
            APIKeys.KEY = key;
            APIKeys.SECRET = secret;
        }


        const string QUERY_URL = "https://data.gateio.io/";

        const string TRADE_URL = "https://api.gateio.io/";

        const string PAIRS_URL = "api2/1/pairs";
        const string MARKET_INFO_URL = "api2/1/marketinfo";
        const string MARKET_LIST_URL = "api2/1/marketlist";
        const string TICKETS_URL = "api2/1/tickers";
        const string TICKER_URL = "api2/1/ticker";
        const string ORDER_BOOKS_URL = "api2/1/orderBooks";
        const string ORDER_BOOK_URL = "api2/1/orderBook";
        const string TRADE_HISTORY_URL = "api2/1/tradeHistory";

        const string BALANCE_URL = "api2/1/private/balances";
        const string DEPOSIT_ADDRESS_URL = "api2/1/private/depositAddress";
        const string DEPOSITS_WITHDRAWALS_URL = "api2/1/private/depositsWithdrawals";
        const string BUY_URL = "api2/1/private/buy";
        const string SELL_URL = "api2/1/private/sell";
        const string CANCEL_ORDER_URL = "api2/1/private/cancelOrder";
        const string CANCEL_ORDERS_URL = "api2/1/private/cancelOrders";
        const string CANCEL_ALL_ORDERS_URL = "api2/1/private/cancelAllOrders";
        const string GET_ORDER_URL = "api2/1/private/getOrder";
        const string OPEN_ORDERS_URL = "api2/1/private/openOrders";
        const string MY_TRADE_HISTORY_URL = "api2/1/private/tradeHistory";
        const string WITHDRAW_URL = "api2/1/private/withdraw";


        /// <summary>
        /// 所有系统支持的交易对
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> GetPairsAsync()
        {
            try
            {
                var requestUrl = QUERY_URL + PAIRS_URL;
                var response = await _httpClient.GetStringAsync(requestUrl);

                return JsonConvert.DeserializeObject<List<string>>(response);
            }
            catch (TaskCanceledException)
            {
                // 请求超时
                throw new BotException("1001");
            }
            catch (HttpRequestException)
            {
                throw new BotException("1001");
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception)
            {
                throw new BotException();
            }
        }

        /// <summary>
        /// 交易市场订单参数
        /// </summary>
        /// <returns>返回所有系统支持的交易市场的参数信息，包括交易费，最小下单量，价格精度等。</returns>
        public static async Task<Dictionary<string, PairInfo>> GetMarketInfoAsync()
        {
            try
            {
                var requestUrl = QUERY_URL + MARKET_INFO_URL;
                var json = await GetReqAsync(requestUrl);

                var dic = new Dictionary<string, PairInfo>();

                dynamic parse = JToken.Parse(json) as dynamic;

                if (parse.result == "true")
                {
                    JArray jarray = parse.pairs as JArray;

                    var pairs = jarray.ToObject<List<Dictionary<string, PairInfo>>>();

                    foreach (Dictionary<string, PairInfo> item in pairs)
                    {
                        var t = item.First();
                        dic.Add(t.Key, t.Value);
                    }
                }

                return dic;
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 交易市场详细行情
        /// </summary>
        /// <returns>返回所有系统支持的交易市场的详细行情和币种信息，包括币种名，市值，供应量，最新价格，涨跌趋势，价格曲线等。</returns>
        public static async Task<List<MarketInfo>> GetMarketListAsync()
        {
            try
            {
                var requestUrl = QUERY_URL + MARKET_LIST_URL;
                var json = await GetReqAsync(requestUrl);

                dynamic parse = JToken.Parse(json) as dynamic;

                var list = new List<MarketInfo>();

                if (parse.result == "true")
                {
                    JArray jarray = parse.data as JArray;

                    list = jarray.ToObject<List<MarketInfo>>();
                }

                return list;

            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }

        /// <summary>
        /// 所有交易行情
        /// </summary>
        /// <returns>返回系统支持的所有交易对的 最新，最高，最低 交易行情和交易量，每10秒钟更新</returns>
        public static async Task<Dictionary<string, TradeInfo>> GetTickersAsync()
        {
            try
            {
                var requestUrl = QUERY_URL + TICKETS_URL;
                var json = await GetReqAsync(requestUrl);

                var dic = JsonConvert.DeserializeObject<Dictionary<string, TradeInfo>>(json);

                return dic;
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }

        /// <summary>
        /// 单项交易行情
        /// </summary>
        /// <param name="currA">被兑换货币</param>
        /// <param name="currB">兑换货币</param>
        /// <returns>返回最新，最高，最低 交易行情和交易量，每10秒钟更新</returns>
        public static async Task<TradeInfo> GetTickerAsync(string currA, string currB)
        {
            try
            {
                var requestUrl = $"{QUERY_URL}{TICKER_URL}/{currA}_{currB}";
                var json = await GetReqAsync(requestUrl);

                return JsonConvert.DeserializeObject<TradeInfo>(json);
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 市场深度
        /// </summary>
        /// <returns>返回系统支持的所有交易对的市场深度（委托挂单），其中 asks 是委卖单, bids 是委买单。</returns>
        public static async Task<Dictionary<string, MarketDeep>> OrderBooksAsync()
        {
            try
            {
                var requestUrl = QUERY_URL + ORDER_BOOKS_URL;
                var json = await GetReqAsync(requestUrl);

                var dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);


                var result = new Dictionary<string, MarketDeep>();

                foreach (var item in dic)
                {
                    if (item.Value.result == "true")
                    {
                        var marketDeep = new MarketDeep();

                        var asks = item.Value.asks as JArray;
                        var bids = item.Value.bids as JArray;

                        foreach (var ask in asks.Values<JArray>())
                        {
                            var v = ask.ToObject<List<decimal>>();
                            marketDeep.Asks.Add(new Deep
                            {
                                Price = v.ElementAt(0),
                                Amount = v.ElementAt(1)
                            });
                        }

                        foreach (var bid in bids)
                        {
                            var v = bid.ToObject<List<decimal>>();
                            marketDeep.Bids.Add(new Deep
                            {
                                Price = v.ElementAt(0),
                                Amount = v.ElementAt(1)
                            });
                        }

                        result.Add(item.Key, marketDeep);
                    }
                }

                return result;
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 单项市场深度
        /// </summary>
        /// <param name="currA">被兑换货币</param>
        /// <param name="currB">兑换货币</param>
        /// <returns></returns>
        public static async Task<MarketDeep> OrderBookAsync(string currA, string currB)
        {
            try
            {
                var requestUrl = $"{QUERY_URL}{ORDER_BOOK_URL}/{currA}_{currB}";
                var json = await GetReqAsync(requestUrl);

                dynamic parse = JToken.Parse(json) as dynamic;

                var marketDeep = new MarketDeep();

                if (parse.result == "true")
                {

                    var asks = parse.asks as JArray;
                    var bids = parse.bids as JArray;

                    foreach (var ask in asks.Values<JArray>())
                    {
                        var v = ask.ToObject<List<decimal>>();
                        marketDeep.Asks.Add(new Deep
                        {
                            Price = v.ElementAt(0),
                            Amount = v.ElementAt(1)
                        });
                    }

                    foreach (var bid in bids)
                    {
                        var v = bid.ToObject<List<decimal>>();
                        marketDeep.Bids.Add(new Deep
                        {
                            Price = v.ElementAt(0),
                            Amount = v.ElementAt(1)
                        });
                    }
                }

                return marketDeep;

            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }

        /// <summary>
        /// 历史成交记录
        /// </summary>
        /// <param name="currA"></param>
        /// <param name="currB"></param>
        /// <param name="tradeId">交易Id，指定后返回交易Id之后的1000条交易记录</param>
        /// <returns>返回最新30条历史成交记录（文档说80条，实际测试只有30条）</returns>
        public static async Task<List<TradeHistory>> TradeHistoryAsync(string currA, string currB, int? tradeId = null)
        {
            try
            {
                var tradeHistories = new List<TradeHistory>();

                var requestUrl = $"{QUERY_URL}{TRADE_HISTORY_URL}/{currA}_{currB}";
                if (tradeId.HasValue)
                {
                    requestUrl += $"/{tradeId.Value}";
                }
                var json = await GetReqAsync(requestUrl);
                // System.Console.WriteLine(json);


                dynamic parse = JToken.Parse(json) as dynamic;

                if (parse.result == "true")
                {
                    JArray data = parse.data as JArray;

                    tradeHistories = data.ToObject<List<TradeHistory>>();
                }

                return tradeHistories;
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 获取账户资金余额
        /// </summary>
        /// <returns></returns>
        public static async Task<Balance> GetBalancesAsync()
        {
            try
            {
                var requestUrl = TRADE_URL + BALANCE_URL;

                var json = await PostReqAsync(requestUrl);

                var parse = JToken.Parse(json) as dynamic;

                if (parse.result == "true")
                {
                    var balance = new Balance();
                    if (parse.available != null)
                    {
                        balance.Available = parse.available.ToObject<Dictionary<string, decimal>>();
                    }
                    if (parse.locked != null)
                    {
                        balance.Locked = parse.locked.ToObject<Dictionary<string, decimal>>();
                    }

                    return balance;
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 获取充值地址
        /// </summary>
        /// <param name="currency">币种 如(BTC, LTC)</param>
        /// <returns></returns>
        public static async Task<string> DepositAddressAsync(string currency)
        {
            try
            {
                var requestUrl = TRADE_URL + DEPOSIT_ADDRESS_URL;

                var form = new Dictionary<string, string>
            {
                {"currency",currency}
            };

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;

                if (parse.result == "true")
                {
                    // 有可能返回的是 New address is being generated for you, please wait a moment and refresh this page.
                    return parse.addr.ToString();
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 获取充值提现历史API
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">终止时间</param>
        /// <returns></returns>
        public static async Task<DWHistory> DepositsWithdrawalsAsync(DateTime? start = null, DateTime? end = null)
        {
            try
            {
                long? s = null;
                long? e = null;
                if (start.HasValue)
                {
                    s = new DateTimeOffset(start.Value).ToUnixTimeSeconds();
                }
                if (end.HasValue)
                {
                    e = new DateTimeOffset(end.Value).ToUnixTimeSeconds();
                }

                var requestUrl = TRADE_URL + DEPOSITS_WITHDRAWALS_URL;

                var form = new Dictionary<string, string>();
                if (s.HasValue)
                {
                    form.Add("start", s.ToString());
                }
                if (e.HasValue)
                {
                    form.Add("end", e.ToString());
                }

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "true")
                {
                    var dwHistory = new DWHistory();

                    var deposits = parse.deposits as JArray;
                    var withdraws = parse.withdraws as JArray;

                    dwHistory.Deposits = deposits.ToObject<List<DWInfo>>();
                    dwHistory.Withdraws = withdraws.ToObject<List<DWInfo>>();

                    return dwHistory;
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }

        /// <summary>
        /// 下单交易买入
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task<string> BuyAsync(OrderReq order)
        {
            try
            {
                //TODO 验证传过来的数据是否有效

                var requestUrl = TRADE_URL + BUY_URL;

                var form = new Dictionary<string, string>();
                form.Add("currencyPair", order.CurrencyPair);
                form.Add("rate", order.Rate.ToString());
                form.Add("amount", order.Amount.ToString());

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "true")
                {
                    //返回的结果里只有orderNumber
                    return parse.orderNumber.ToString();
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }

        /// <summary>
        /// 下单交易卖出
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task<string> SellAsync(OrderReq order)
        {
            try
            {
                //TODO 验证传过来的数据是否有效

                var requestUrl = TRADE_URL + SELL_URL;

                var form = new Dictionary<string, string>();
                form.Add("currencyPair", order.CurrencyPair);
                form.Add("rate", order.Rate.ToString());
                form.Add("amount", order.Amount.ToString());

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "true")
                {
                    //返回的结果里只有orderNumber
                    return parse.orderNumber.ToString();
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 取消下单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static async Task CancelOrderAsync(CancelOrderReq order)
        {
            try
            {
                var requestUrl = TRADE_URL + CANCEL_ORDER_URL;

                var form = new Dictionary<string, string>();
                form.Add("orderNumber", order.OrderNo);
                form.Add("currencyPair", order.CurrencyPair);

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "false")
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }

        /// <summary>
        /// 取消多个订单
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static async Task CancelOrdersAsync(IEnumerable<CancelOrderReq> orders)
        {
            throw new BotException("1003");

            var requestUrl = TRADE_URL + CANCEL_ORDERS_URL;

            var form = new Dictionary<string, string>();

            var orderJson = JsonConvert.SerializeObject(orders);

            form.Add("orders_json", orderJson);

            var json = await PostReqAsync(requestUrl, form);

            var parse = JToken.Parse(json) as dynamic;
            if (parse.result == "false")
            {
                var code = parse.code.ToString();
                var message = parse.message.ToString();

                throw new BotException(code, message);
            }
        }


        /// <summary>
        /// 取消所有下单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static async Task CancelAllOrdersAsync(CancelAllOrdersReq req)
        {
            try
            {
                var requestUrl = TRADE_URL + CANCEL_ALL_ORDERS_URL;

                var form = new Dictionary<string, string>();
                form.Add("type", ((int)req.Type).ToString());
                form.Add("currencyPair", req.CurrencyPair);

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "false")
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 获取下单状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static async Task<GetOrderRes> GetOrderAsync(GetOrderReq req)
        {
            try
            {
                var requestUrl = TRADE_URL + GET_ORDER_URL;

                var form = new Dictionary<string, string>();
                form.Add("orderNumber", req.OrderNo);
                form.Add("currencyPair", req.CurrencyPair);

                var json = await PostReqAsync(requestUrl, form);

                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "true")
                {
                    return parse.order.ToObject<GetOrderRes>();
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 获取我的当前挂单列表
        /// </summary>
        /// <returns></returns>
        public static async Task<List<OpenOrderRes>> OpenOrdersAsync()
        {
            try
            {
                var requestUrl = TRADE_URL + OPEN_ORDERS_URL;

                var form = new Dictionary<string, string>();

                var json = await PostReqAsync(requestUrl, form);


                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "true")
                {
                    return parse.orders.ToObject<List<OpenOrderRes>>();
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        /// <summary>
        /// 获取我的24小时内成交记录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static async Task<List<MyTradeHistory>> MyTradeHistoryAsync(MyTradeHistoryReq req)
        {
            try
            {
                var requestUrl = TRADE_URL + MY_TRADE_HISTORY_URL;

                var form = new Dictionary<string, string>();
                form.Add("currencyPair", req.CurrencyPair);
                form.Add("orderNumber", req.OrderNo);

                var json = await PostReqAsync(requestUrl, form);


                var parse = JToken.Parse(json) as dynamic;
                if (parse.result == "true")
                {
                    return parse.trades.ToObject<List<MyTradeHistory>>();
                }
                else
                {
                    var code = parse.code.ToString();
                    var message = parse.message.ToString();

                    throw new BotException(code, message);
                }
            }
            catch (JsonSerializationException)
            {
                throw new BotException("1002");
            }
            catch (Exception ex)
            {
                throw new BotException("1000", ex.Message);
            }
        }


        private static async Task<string> GetReqAsync(string requestUrl)
        {
            try
            {
                return await _httpClient.GetStringAsync(requestUrl);
            }
            catch (TaskCanceledException)
            {
                // 请求超时
                throw new BotException("1001");
            }
            catch (HttpRequestException)
            {
                throw new BotException("1001");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw new BotException("1000", ex.Message);
            }
        }


        private static async Task<string> PostReqAsync(string requestUrl, Dictionary<string, string> form = null)
        {
            try
            {
                form = form ?? new Dictionary<string, string>();

                _httpClient.DefaultRequestHeaders.Add("KEY", APIKeys.KEY);
                _httpClient.DefaultRequestHeaders.Add("SIGN", await GetSign(form));

                var httpContent = new FormUrlEncodedContent(form);

                var response = await _httpClient.PostAsync(requestUrl, httpContent);

                return await response.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException)
            {
                // 请求超时
                throw new BotException("1001");
            }
            catch (HttpRequestException)
            {
                throw new BotException("1001");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw new BotException("1000", ex.Message);
            }

        }


        private static async Task<string> GetSign(Dictionary<string, string> form = null)
        {
            form = form ?? new Dictionary<string, string>();

            var content = new FormUrlEncodedContent(form);
            var encodedForm = await content.ReadAsStringAsync();


            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(APIKeys.SECRET);
            var formBytes = encoding.GetBytes(encodedForm);

            var sha512 = new HMACSHA512(keyBytes);
            var hashBytes = sha512.ComputeHash(formBytes);

            var sign = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return sign;
        }
    }
}