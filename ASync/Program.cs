using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASync
{
    class Program
    {
        static void Main(string[] args)
        {
            PagePaint();
        }
        static void PagePaint()
        {
            Console.WriteLine("PagePaint：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("Paint Start");
            //使用Await和不适用Await的区别
            var result = PaintAds();
            var resultFirst = PaintAdsFirst();
            //var content = resultFirst.Result; 假如使用Task的返回值，则会等待异步执行完成，且会阻塞线程，这是和使用await的最大区别；
            Thread.Sleep(3000);
            Console.WriteLine("Paint End");
            Console.WriteLine("PagePaint：" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        async static Task PaintAds()
        {
            //开启线程异步执行，下面代码不会执行
            string result = await Task.Run(() =>
              {
                  Thread.Sleep(1000);
                  Console.WriteLine("PaintAds Before：" + Thread.CurrentThread.ManagedThreadId.ToString());
                  return "666";
              });
            Console.WriteLine("PaintAds After：" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        static Task<string> PaintAdsFirst()
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
