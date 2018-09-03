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

            #region 并行linq
            ParallelLinq.ParallelA();
             ParallelLinq.ParallelB();
            #endregion

            #region  使用Await和不适用Await的区别
            //使用Await和不适用Await的区别
            var result = AsyncDome.PaintAds();
            Console.WriteLine("AsyncDome.PaintAds Thread：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("AsyncDome.PaintAds Result：" + result.Result);
            var resultFirst = AsyncDome.PaintAdsFirst();
            Console.WriteLine("AsyncDome.resultFirst Thread：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("AsyncDome.resultFirst Result：" + resultFirst.Result);
            //var content = resultFirst.Result; 假如使用Task的返回值，则会等待异步执行完成，且会阻塞线程，这是和使用await的最大区别；
            #endregion

            #region Demo2 - 带参数的委托
            try
            {
                throw new Exception("ConsoleError");
            }
            catch (Exception e)
            {
                ActionMethod.GetTaskAction((ex) =>
                {
                    Console.WriteLine(ex.Message);
                    var d = ex.Message;
                })(e);//第二个括号里面是参数
            }
            #endregion

            #region Task Class
            AwaitTask();
            #endregion

            Console.WriteLine("Paint End");
            Thread.Sleep(3000);
            Console.WriteLine("PagePaint：" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
        public async static void AwaitTask()
        {
            Console.WriteLine("T Start!");
            await AttendanceTask.UserDefinedTask.AddAsyncTask(() => { Console.WriteLine("Action逻辑!"); }, () => { Console.WriteLine("Success Action!"); }, (ex) => { Console.WriteLine("Faild Action!"); });//后面代码会被阻塞
            Console.WriteLine("T Completed!");
        }


    }

}
