using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflect.cs
{
    class Program
    {
        static void Main(string[] args)
        {

            Type type = typeof(Class1<int>);
            object o = Activator.CreateInstance(type);
            type.InvokeMember("Test", BindingFlags.Default | BindingFlags.InvokeMethod, null, o, new object[] { 123 });

            var typeList = typeof(List<>);
            Type typeDataList = typeList.MakeGenericType(typeof(DateTime)); //通过List<>构建出List<DateTime>

            var invoker = Activator.CreateInstance(typeDataList);

            Type generic = typeof(Dictionary<,>);
            DisplayTypeInfo(generic);
        }
        private static void DisplayTypeInfo(Type t)
        {
            Console.WriteLine("\r\n{0}", t);

            Console.WriteLine("\tIs this a generic type definition? {0}",
                t.IsGenericTypeDefinition);

            Console.WriteLine("\tIs it a generic type? {0}",
                t.IsGenericType);

            Type[] typeArguments = t.GetGenericArguments();
            Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
            foreach (Type tParam in typeArguments)
            {
                Console.WriteLine("\t\t{0}", tParam);
            }
        }
    }

    class Class1<T>
    {
        public void Test(T t)
        {
            Console.WriteLine(t);
        }
    }
    public class A
    {
        public void Test(string ss)
        {
            Console.WriteLine("T t");
        }
        // 未找到方法“Reflect.cs.Class1`1[[Reflect.cs.A, Reflect.cs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]].Test”。

    }
}
