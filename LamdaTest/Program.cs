using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            object o1 = "1";
            object o2 = "2";
            object o3 = "1";
            object o4 = null;
            if (o1==o3)
            {
                string test = "";
            }
            string[] tt0 = { "z", "2" };
            string[] tt1 = { "z", "2" };
            string[] tt2 = { "g", "21" };
            string[] tt3 = { "g", "2131" };
            List<string[]> list = new List<string[]>();
            list.Add(tt0);
            list.Add(tt1);
            list.Add(tt2);
            list.Add(tt3);
            var s111 = list.GroupBy(n => n[0] + n[1]).ToList();
            Func<Person> f1 = () => new Person();
            var ddd = new Lazy<Person>(f1);


            List<Person> persons1 = new List<Person>();
            persons1.Add(new Person("张,三", "男", 20, 1500, 123));
            persons1.Add(new Person("张三111", "男", 20, 1500, 123));
            persons1.Add(new Person("王成", "男", 32, 3200, 123));
            persons1.Add(new Person("李,丽", "女", 19, 1700, 123));
            persons1.Add(new Person("何英", "女", 35, 3600, 22));
            persons1.Add(new Person("何英", "女", 18, 1600, 33));

            #region

            var t1 = persons1.Select(n => n.Name.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            #endregion


            #region First方法为Null校验
            var ssss = persons1.Where(p => p.Age == 20);
            //报错代码
            var ssss1 = persons1.Where(p => p.Age == 2550).ToList();

            if (ssss1 == null)
            {

            }
            if (ssss1.Any())
            {

            }


            if (ssss == null)
            {

            }
            if (ssss.Any())
            {

            }
            #endregion

            var sss = persons1.Where(w => w.Name == "asdf").First();

            var tt = persons1.GroupBy(model => model.UserId).ToList();

            var sums1 = persons1.GroupBy(x => x.UserId).Select(s => new { name = s.Key, s = s.ToList() }).ToList();
            sums1.ForEach(model =>
                {

                    var tt11 = model.s;

                });


            var sums = persons1.OrderByDescending(o => o.Age)
            .GroupBy(x => x.UserId)
            .Select(group => new
            {
                Peo = group.Key,
                //first = group.OrderByDescending(model => model.Age).First(),
                name = group.Select(m => m.Name).First(),
                name1 = group.Select(m => m.Name).Last(),
                age = group.Select(m => m.Age).First()

            }).ToList();

            // tt.OrderByDescending(model => model.a);
        }
    }
    /// <summary>  
    /// 手动设计一个Person类。用于放到List泛型中  
    /// </summary>  
    public class Person
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Age { get; private set; }
        public string Sex { get; set; }
        public int Money { get; set; }
        public Person() { }
        public Person(string name, string sex, int age, int money, int userId)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Money = money;
            UserId = userId;
        }
    }
}
