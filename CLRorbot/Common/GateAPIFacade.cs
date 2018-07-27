using gateio.api.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CLRorbot.Common
{
    public class GateAPIFacade
    {

        public static string HUOBI_HOST_URL, ApiKey, SecereKey;
        private RestClient client;

        public GateAPIFacade(string apikey, string secerekey, string url = "https://data.gateio.io")
        {
            HUOBI_HOST_URL = url;
            ApiKey = apikey;
            SecereKey = secerekey;
            client = new RestClient();
            client = new RestClient(HUOBI_HOST_URL);
            client.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded");
            client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");
              gateio.api.API.SetKey(ApiKey, SecereKey);
        }



        /// <summary>
        /// 无加密请求（适用获取行情）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T SendRequestContent<T>(string resourcePath, string parameters = "") where T : new()
        {
            var url = $"{HUOBI_HOST_URL}{resourcePath}{parameters}";

            var request = new RestRequest(url, Method.GET);
            var result = client.Execute(request);

            if (result.Content == null || result.Content == string.Empty)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(result.Content);


        }


        /// <summary>
        /// 无加密请求POS（适用获取行情）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T SendRequestContentPost<T>(string resourcePath, string parameters = "") where T : new()
        {
            var url = $"{HUOBI_HOST_URL}{resourcePath}{parameters}";

            var request = new RestRequest(url, Method.POST);
            var result = client.Execute(request);

            if (result.Content == null || result.Content == string.Empty)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(result.Content);
        }





        /// <summary>
        /// 获取行情
        /// </summary>
        /// <returns></returns>
        public GateMarketModel MarketList()
        {
            string url = "/api2/1/marketlist";
            GateMarketModel model = new GateMarketModel();
            return SendRequestContent<GateMarketModel>(url);

        }

         public GatebalancesModel GetBlance()
        {
            HUOBI_HOST_URL = "https://api.gateio.io";
            string url = "/api2/1/private/balances";

            client.AddDefaultHeader("KEY", "2D359374-04C8-4A74-8019-04A7455146F8");

            var sign = GetSign(null);
          
            client.AddDefaultHeader("SIGN", sign);

            return SendRequestContentPost<GatebalancesModel>(url);

        }




        private static string GetSign(Dictionary<string, string> form = null)
        {
            form = form ?? new Dictionary<string, string>();

            var content = new FormUrlEncodedContent(form);
            var encodedForm =  content.ReadAsStringAsync();


            var encoding = new UTF8Encoding();
            var keyBytes = encoding.GetBytes(SecereKey);
            var formBytes = encoding.GetBytes(encodedForm.Result.ToString());

            var sha512 = new HMACSHA512(keyBytes);
            var hashBytes = sha512.ComputeHash(formBytes);

            var sign = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return sign;
        }



    }
}
