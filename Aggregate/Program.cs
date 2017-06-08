using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            Tets();
            Dictionary<int, List<Marketing>> dic = new Dictionary<int, List<Marketing>>();

            //普通活动
            if (!dic.ContainsKey(1))
                dic[1] = new List<Marketing>();
            dic[1].Add(new Marketing() { MarketingID = 1, MarketingName = "普通活动1" });
            dic[1].Add(new Marketing() { MarketingID = 1, MarketingName = "普通活动2" });

            //事件活动
            if (!dic.ContainsKey(2))
                dic[2] = new List<Marketing>();
            dic[2].Add(new Marketing() { MarketingID = 3, MarketingName = "事件活动1" });
            dic[2].Add(new Marketing() { MarketingID = 4, MarketingName = "事件活动2" });


            List<Marketing> marketingListTotal = new List<Marketing>();
            Marketing mark1 = new Marketing();
            mark1.MarketingID = 123;
            mark1.MarketingName = "asdfasf";
            marketingListTotal.Add(mark1);
            var marketingList = dic.Keys.Aggregate(marketingListTotal, (total, next) =>
              {
                  var to = total;
                  var ne = next;
                  return total.Union(dic[next]).ToList();
              });
        }
        public static void Tets()
        {
            string[] words = new string[] { "Able", "was", "I", "ere", "I", "saw", "Elba" };
            string s = words.Aggregate((a, n) => a + " " + n);
            Console.WriteLine(s);
        }
    }
    public class Marketing
    {
        public int MarketingID { get; set; }
        public string MarketingName { get; set; }
    }
}
