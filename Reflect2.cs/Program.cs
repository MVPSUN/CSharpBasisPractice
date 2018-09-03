using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflect2.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionTest rt = new ReflectionTest();
            MethodInfo mi = rt.GetType().GetMethod("DisplayType");//先获取到DisplayType<T>的MethodInfo反射对象
            var t11 = mi.MakeGenericMethod(new Type[] { typeof(string) });
            t11.Invoke(rt, new object[] { "asdf" });//然后使用MethodInfo反射对象调用ReflectionTest类的DisplayType<T>方法，这时要使用MethodInfo的MakeGenericMethod函数指定函数DisplayType<T>的泛型类型T

            Type myGenericClassType = rt.GetType().GetNestedType("MyGenericClass`1");//这里获取MyGenericClass<T>的Type对象，注意GetNestedType方法的参数要用MyGenericClass`1这种格式才能获得MyGenericClass<T>的Type对象
            myGenericClassType.MakeGenericType(new Type[] { typeof(float) }).GetMethod("DisplayNestedType", BindingFlags.Static | BindingFlags.Public).Invoke(null, null);
            //然后用Type对象的MakeGenericType函数为泛型类MyGenericClass<T>指定泛型T的类型，比如上面我们就用MakeGenericType函数将MyGenericClass<T>指定为了MyGenericClass<float>，然后继续用反射调用MyGenericClass<T>的DisplayNestedType静态方法

            Console.ReadLine();
        }
    }
    public class ReflectionTest
    {
        //泛型类MyGenericClass有个静态函数DisplayNestedType
        public class MyGenericClass<T>
        {
            public static void DisplayNestedType()
            {
                Console.WriteLine(typeof(T).ToString());
            }
        }

        public void DisplayType<T>(string tt)
        {
            Console.WriteLine(typeof(T).ToString());
        }
    }
    public class MyGenericClass<T>
    {
        public static void DisplayNestedType()
        {
            Console.WriteLine(typeof(T).ToString());
        }
    }
}
