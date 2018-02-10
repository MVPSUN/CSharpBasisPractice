using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicKnowLedge
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new { a = 1 };
            object obj1 = new { a = 1 };
        }
    }
    public class Parent
    {
        //没有Set无法给ParentName进行赋值
        public string ParentName { get; }
        public void ParentMethod()
        {
            //获取当前命名空间名称
            string thisNamespace = GetType().Namespace;
            Console.WriteLine("Fu Lei");

        }
    }
}
