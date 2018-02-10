using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace AttributePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Hoopster dd = new Hoopster();
            var type = dd.GetType();
            dd.Play();
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    public class TestAttribute : Attribute
    {

    }
    //  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.ReturnValue | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
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
        [DataMember]
        [Country("China")]
        public string Name22 { get; set; }
        [Country("Sports", PlayerCount = 2)]
        public virtual void Play()
        {
            Console.WriteLine("Play");
        }
    }
    public class Hoopster : Sportsman
    {
        [DataMember]
        [Country("China")]
        public string Name11111 { get; set; }
        [Country("Bill", PlayerCount = 2)]
        public override void Play()
        {
            Type commandType = this.GetType();
            try
            {

                var methods = commandType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(s => s.Name == "AAA").ToList();

                var tt = (Action<string>)Delegate.CreateDelegate(typeof(Action<string>), null, methods[0]);
                //  tt("ddd");
                var tt2 = (Action<string>)Delegate.CreateDelegate(typeof(Action<string>), this, methods[0]);
                //    tt("ddd");


                var methods2 = commandType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                var methods3 = commandType.GetMethods(BindingFlags.Instance);
                var methods4 = commandType.GetMethods(BindingFlags.Public);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }


            #region Attr
            var props = commandType.GetProperties();
            List<string> errorList = new List<string>();

            foreach (var prop in props)
            {
                var list = prop.GetCustomAttributes(typeof(Attribute), true);

            }
            MemberInfo[] members = this.GetType().GetMembers();
            foreach (MemberInfo member in members)
            {
                Attribute test11Attr = member.GetCustomAttribute(typeof(CountryAttribute), true);
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
            #endregion
        }


        public void AAA(string tt)
        {
            var sss = "asdfasf";
        }
        public void BBB()
        {

        }
    }
}
