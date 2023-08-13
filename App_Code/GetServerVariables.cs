using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


public class GetServerVariables
{
    public static string GetIp()
    {
        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return ip;
    }

    public static string GetUserCity(string ip)
    {
        IpInfo ipInfo = new IpInfo();
        try
        {
            string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
            //string info = new WebClient().DownloadString("http://ipinfo.io/179.50.79.61");
            ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            RegionInfo myRI1 = new RegionInfo(ipInfo.Country);

            //ipInfo.Country = myRI1.EnglishName;
        }
        catch (Exception ex)
        {
            ipInfo.City = "Desconocida";
        }

        return ipInfo.City;
    }
    public class IpInfo
    {
        private string _city;

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("city")]
        public string City
        {
            get { return _city; }
            set
            {
                byte[] bytes = Encoding.Default.GetBytes(value);
                _city = Encoding.UTF8.GetString(bytes);
            }
        }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("loc")]
        public string Loc { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("postal")]
        public string Postal { get; set; }
    }

}

