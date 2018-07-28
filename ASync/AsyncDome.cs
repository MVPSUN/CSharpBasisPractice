using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASync
{
    public class AsyncDome
    {
        public async static Task<string> PaintAds()
        {
            //开启线程异步执行，下面代码不会执行
            string result = await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("PaintAds Before：" + Thread.CurrentThread.ManagedThreadId.ToString());
                return "666";
            });
            Console.WriteLine("PaintAds After：" + Thread.CurrentThread.ManagedThreadId.ToString());
            return result;
        }
        public static Task<string> PaintAdsFirst()
        {
            //开启线程异步执行，下面代码继续执行
            var result = Task.Run(() =>
            {
                Console.WriteLine("PaintAds1 Before：" + Thread.CurrentThread.ManagedThreadId.ToString());
                return "d";
            });
            Console.WriteLine("PaintAds1 After：" + Thread.CurrentThread.ManagedThreadId.ToString());
            return result;
        }
    }
}
