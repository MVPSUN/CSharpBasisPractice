using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex_
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryString = string.Format("appaccount_id={0}", "ddddddddddddddddd");
            var url = "http://appconnect-test.beisencorp.com/user/authorize?tenant_id=107106&appaccount_id=2056d796-260e-4007-87f6-1a8e0ef9efa1&app_id=909&redirect_url=http%3a%2f%2fwww.italent.cn%2fv1%2fsso%2fitalent%2fauth%3freturn_url%3dhttp%253a%252f%252fcloud.italent.cn";
            var Url = DealQueryString(url, queryString);
        }
        private static  string DealQueryString(string url, string queryString)
        {
            var arr = queryString.Split('&');
            foreach (var item in arr)
            {
                var arrSub = item.Split('=');
                url = DealQueryString(url, arrSub[0], arrSub[1]);
            }
            return url;
        }
        private static string DealQueryString(string url, string key, string val)
        {
            var exp = key + "=([^&]*)";
            var r = new Regex(exp);
            if (r.IsMatch(url))
            {
                url = r.Replace(url, key + "=" + val);
            }
            else
            {
                url += url.Contains("?") ? "&" : "?";
                url += key + "=" + val;
            }
            return url;
        }
    }
}
