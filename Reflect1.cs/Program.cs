using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflect1.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Class1<>);
            type = type.MakeGenericType(new Type[] { typeof(string) });
            object o = Activator.CreateInstance(type);
            type.InvokeMember("Test", BindingFlags.Public | BindingFlags.InvokeMethod, null, o, null);
        }
    }
    public class Class1<T>
    {
        public static void Test()
        {
            Console.WriteLine(typeof(T).ToString());
        }

    }
    public class Class11<String>
    {
        public static void Test()
        {
            Console.WriteLine("");
        }

    }
}
