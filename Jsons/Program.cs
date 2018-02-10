using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;


namespace Jsons
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string d = "909_21";
                var tt = d.Split('_');
                var resul111t = tt[tt.Length];
                var result = "{ 'errcode': 0,'errmsg': 'ok', 'userid': '123','deviceId':'DEVICEID','is_sys': false, 'sys_level': 2}";
                var json = SerializeHelper.Deserialize<JObject>(null);
                var json2 = SerializeHelper.Deserialize<JObject>("");
                var json3 = SerializeHelper.Deserialize<JObject>(result);
            }
            catch (Exception ex)
            {
                var dd = ex.Message;
            }

        }
    }
    public class SerializeHelper
    {
        /// <summary>
        /// 反序列化请求结果
        /// </summary>
        /// <typeparam name="T">继承自Result的实体</typeparam>
        /// <param name="requestContent">返回结果</param>
        /// <returns></returns>
        public static T Deserialize<T>(string requestContent)
        {
            var jsonSerializer = new JsonSerializer();
            JsonReader reader = new JsonTextReader(new StringReader(requestContent));
            return jsonSerializer.Deserialize<T>(reader);
        }

        /// <summary>
        /// 序列化请求的body
        /// </summary>
        /// <typeparam name="T">请求的body的类型</typeparam>
        /// <param name="obj">请求的body</param>
        /// <returns>json序列化后的body字符串</returns>
        public static string Serialize<T>(T obj)
        {
            var jsonSerializer = new JsonSerializer();
            var json = new StringBuilder();
            var write = new StringWriter(json);
            jsonSerializer.Serialize(write, obj);
            return json.ToString();
        }
    }
}
