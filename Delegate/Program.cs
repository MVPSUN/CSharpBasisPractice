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
            //FuncClass funcClass = new FuncClass();
            //funcClass.Test();
            DelegateMethod delegateMethod = new DelegateMethod(ZhangSan.PayHouse);
            delegateMethod += new DelegateMethod(ZhangSan.PayHouse1);
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
        public static void PayHouse1()
        {
            string content = "委托你买个小宇宙111111111";
            Console.WriteLine(content);
        }
    }
}
