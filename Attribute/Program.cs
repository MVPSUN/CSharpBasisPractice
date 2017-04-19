using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Hoopster dd = new Hoopster();
            dd.Play();
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class TestAttribute : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.ReturnValue | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CountryAttribute : Attribute
    {
        public CountryAttribute()
        {

        }
        public CountryAttribute(string name)
        {
            this.Name = name;
        }
        public int PlayerCount { get; set; }
        public string Name { get; set; }
    }
    [Country("China")]
    [Country("America")]
    public class Sportsman
    {
        public string Name { get; set; }
        [Country("Sports", PlayerCount = 2)]
        public virtual void Play()
        {
            Console.WriteLine("Play");
        }
    }
    public class Hoopster : Sportsman
    {
        [Country("Bill", PlayerCount = 2)]
        public override void Play()
        {
            MemberInfo[] members = this.GetType().GetMembers();
            foreach (MemberInfo member in members)
            {
                Attribute testAttr = Attribute.GetCustomAttribute(member, typeof(TestAttribute));
                if (testAttr != null && testAttr is TestAttribute)
                {
                    // Console.WriteLine(((TestAttribute)testAttr).Message);
                }
                if (Attribute.IsDefined(member, typeof(CountryAttribute)))
                {
                    Attribute[] attributes = Attribute.GetCustomAttributes(member);
                    foreach (Attribute item in attributes)
                    {
                        CountryAttribute attr = item as CountryAttribute;
                        if (attr != null)
                        {
                            Console.WriteLine(string.Format("运动类型：{0}  运动员人数：{1}", attr.Name, attr.PlayerCount));
                        }
                    }
                }
            }
        }
    }
}
