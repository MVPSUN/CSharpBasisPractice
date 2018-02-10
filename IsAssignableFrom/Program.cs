using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAssignableFrom
{
    /// <summary>
    ///  isAssignableFrom 确定指定类型的实例是否可以分配给当前类型的实例。；isAssignableFrom针对class对象
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent();
            parent.ParentMethod();
            //parent.ParentName = "无法Set赋值";
            Type type = typeof(Children);
            var reult = typeof(Parent).IsAssignableFrom(type);
        }
    }
    public class Parent
    {
        public string ParentName { get;  }
        public void ParentMethod()
        {
            string thisNamespace = GetType().Namespace;

            Console.WriteLine("Fu Lei");
        }
    }
    public class Children : Parent
    {
        public string ChildrenName { get; set; }
        public void ChildrenMethod()
        {
            Console.WriteLine("Children");
        }

    }
}
