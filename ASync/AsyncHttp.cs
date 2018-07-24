using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ASync
{
    public class AsyncHttp
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="T">请求返回类型</typeparam>
        /// <param name="apiUrl">请求地址</param>
        /// <returns></returns>
        public static T HttpGet<T>(string apiUrl)
        {
            Task<T> responseTask;
            try
            {
                responseTask = Get<T>(apiUrl);
            }
            catch (Exception e)
            {
                throw new Exception("HttpGet请求异常.ExceptionUrl:" + apiUrl, e);
            }
            return responseTask.Result;
        }

        /// <summary>
        ///HttpClient实现Get请求
        /// </summary>
        private static async Task<T> Get<T>(string url)
        {
            HttpClientHandler handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip };
            using (HttpClient http = new HttpClient(handler))
            {
                HttpResponseMessage response = await http.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                object content = JsonConvert.DeserializeObject(result, typeof(T));
                return (T)content;
            }
        }


        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T">请求返回类型</typeparam>
        /// <param name="apiUrl">请求地址</param>
        /// <param name="obj">post数据对象</param>
        /// <returns></returns>
        public static T HttpPost<T>(string apiUrl, object obj, bool bodyIsJson = true)
        {
            Task<T> responseTask;
            try
            {
                responseTask = Post<T>(apiUrl, obj, bodyIsJson);
            }
            catch (Exception e)
            {

                throw new Exception("HttpPost请求异常.ExceptionUrl:" + apiUrl, e);
            }

            return responseTask.Result;
        }


        /// <summary>
        ///HttpClient实现Post请求
        /// </summary>
        private static async Task<T> Post<T>(string url, object obj, bool bodyIsJson = true)
        {
            HttpClientHandler handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip };
            using (HttpClient http = new HttpClient(handler))
            {

                string strBody = string.Empty;
                if (bodyIsJson)
                {
                    strBody = JsonConvert.SerializeObject(obj);
                }
                else
                {
                    strBody = obj.ToString();
                }
                StringContent bodyContent = new StringContent(strBody);
                if (bodyIsJson)
                {
                    bodyContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                else
                {
                    bodyContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                }


                HttpResponseMessage response = await http.PostAsync(url, bodyContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                object content = JsonConvert.DeserializeObject(result, typeof(T));
                return (T)content;
            }
        }

        public static long ConvertDateTimeInt(DateTime time)
        {

            double intResult = 0;

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            intResult = (time - startTime).TotalSeconds;

            return (long)intResult;

        }


        public static DateTime ConvertIntDatetime(double utc)
        {

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            startTime = startTime.AddSeconds(utc);

            //startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )            

            return startTime;

        }

        /// <summary>    
        /// 将DateTime时间格式转换为Unix时间戳格式    
        /// </summary>    
        /// <param name="time">时间</param>    
        /// <returns>double</returns>    
        public static long DateTimeToUnixTimeStamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
            return t;
        }



        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddMilliseconds(unixTimeStamp);
            return time;
        }


    }
}
