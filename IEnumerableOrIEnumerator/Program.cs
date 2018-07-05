using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableOrIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SelectMany
            //初始化数据  
            School s = new School();
            for (int i = 0; i < 5; i++)
            {
                s.Classes.Add(new Class());
            }
            s.Classes[0].Students.Add(new Student(1, "a0"));
            s.Classes[1].Students.Add(new Student(1, "b0"));
            s.Classes[2].Students.Add(new Student(0, "c0"));
            s.Classes[3].Students.Add(new Student(0, "d0"));
            s.Classes[4].Students.Add(new Student(0, "e0"));
            s.Classes[0].Students.Add(new Student(0, "a1"));
            s.Classes[0].Students.Add(new Student(1, "a1"));
            s.Classes[0].Students.Add(new Student(1, "a2"));
            s.Classes[0].Students.Add(new Student(1, "a3"));
            s.Classes[1].Students.Add(new Student(0, "b1"));
            s.Classes[2].Students.Add(new Student(0, "c1"));
            s.Classes[3].Students.Add(new Student(0, "d1"));
            //取出school下的所有性别是0的student  
            var x1 = s.Classes.SelectMany(b => b.Students);//把结果合并成一个序列
            var x3 = s.Classes.Select(b => b.Students);//返回一个新表各自存储
            #endregion

            Program d = new Program();
            d.Consumer();
        }
        public void Consumer()
        {
            //没有使用迭代块，把全部数据加载到内存当中
            var data = GetData();
            foreach (int i in data)
            {
                Console.WriteLine(i.ToString());
            }
            //使用迭代块
            var content = Integers();
            foreach (int i in content)
            {
                Console.WriteLine(i.ToString());
            }

        }
        /// <summary>
        /// 迭代块
        /// 注释：yield return 集合里面的迭代块，执行时把迭代块加载到内存当中
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetData()
        {
            return new List<int>() { 1, 2, 3, 4 };
        }
    }
}
