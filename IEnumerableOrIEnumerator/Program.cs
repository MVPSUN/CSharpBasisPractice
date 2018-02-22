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
            Program d = new Program();
            d.Consumer();
        }
        public void Consumer()
        {
            var content = Integers();
            var cont1 = content.GetEnumerator();
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
    }
}
