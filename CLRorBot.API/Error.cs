using System.Collections.Generic;

namespace gateio.api
{
    internal static class Error
    {

        static Dictionary<string, string> _errors = new Dictionary<string, string>
        {
            {"1000","内部错误"},
            {"1001","请求错误"},
            {"1002","解析数据错误"},
            {"1003","按照文档传递数据，依然返回Invalid Data"},

            {"1","无效请求"},
            {"2","无效版本"},
            {"3","无效请求"},
            {"4","请求太频繁，稍后重试"},
            {"5","Key或签名无效，请重新创建"},
            {"6","Invalid Data"},
            {"7","币种对不支持"},
            {"8","币种不支持"},
            {"9","币种不支持"},
            {"10","验证错误"},
            {"11","地址获取失败"},
            {"12","参数为空"},
            {"13","系统错误，联系管理员"},
            {"14","无效用户"},
            {"15","撤单太频繁，一分钟后再试"},
            {"16","无效单号，或挂单已撤销"},
            {"17","无效单号"},
            {"18","无效挂单量"},
            {"19","交易已暂停"},
            {"20","挂单量太小"},
            {"21","资金不足"}
        };


        public static string GetErrorByCode(string code)
        {
            if (!_errors.ContainsKey(code))
            {
                throw new System.ArgumentException("错误代码不存在");
            }
            return _errors[code];
        }


    }
}