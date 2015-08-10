using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Services = Btcamp.Crowdfunding.Core.Services;

namespace Btcamp.Crowdfunding.Core.Common
{
    public class ApplicationCommon
    {
        public static string SymbolName { get; private set; }

        public static string USDCNHName { get; private set; }
        static ApplicationCommon()
        {
            SymbolName = ConfigurationManager.AppSettings.Get("app:sysmbolName") ?? "XAUUSD";
            USDCNHName = ConfigurationManager.AppSettings.Get("app:USDCNHName") ?? "USDCNH";
        }
        /// <summary>
        /// 发送HTTP请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="param">请求的参数</param>
        /// <returns>请求结果</returns>
        public static string Request(string url, string param)
        {
            string strURL = url + '?' + param;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            // 添加header
            request.Headers.Add("apikey", "82047a207a04d07332b42b3fe1003c75");
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }
    }

    public class Rate
    {
        public int errNum { get; set; }

        public string errMsg { get; set; }

        public RetData retData { get; set; }

    }
    public class RetData
    {
        public string date { get; set; }
        public string time { get; set; }
        public string fromCurrency { get; set; }
        public int amount { get; set; }
        public string toCurrency { get; set; }
        public double currency { get; set; }

        public double convertedamount { get; set; }
    }
}
