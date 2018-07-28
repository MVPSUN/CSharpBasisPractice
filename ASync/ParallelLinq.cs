using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASync
{
    /// <summary>
    /// 并行Linq
    /// </summary>
    public class ParallelLinq
    {

        public static void ParallelA()
        {
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("A Thread：" + Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("A Value：" + i);
            }
            stop.Stop();
            Console.WriteLine("A method time:" + stop.Elapsed.TotalMilliseconds);
        }
        public static void ParallelB()
        {
            Stopwatch stop = new Stopwatch();
            stop.Start();
            Parallel.For(0, 50, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, i =>
               {
                   Console.WriteLine("B Thread：" + Thread.CurrentThread.ManagedThreadId.ToString());
                   //  Console.WriteLine("B Value：" + i);
               });
            stop.Stop();
            Console.WriteLine("B method time:" + stop.Elapsed.TotalMilliseconds);
        }
    }
}
