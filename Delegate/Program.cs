using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            object t1 = "asdf";
            var ddd = Convert.ToDouble(t1 ?? 0);
            DelegateMethod delegateMethod = new DelegateMethod(ZhangSan.PayHouse);
            delegateMethod();

        }
    }
    public delegate void DelegateMethod();
    public static class ZhangSan
    {
        public static void PayHouse()
        {
            string content = "委托你买个小宇宙";
            Console.WriteLine(content);
        }
    }
}
