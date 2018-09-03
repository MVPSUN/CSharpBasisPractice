using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var tostring = Day.Day1.ToString();
            var dddd = Day.Day1.GetTypeCode().ToString();
            var aaaa = Day.Day1.GetHashCode().ToString();
            var t1 = Enum.GetName(typeof(Day), 1);
            var week = Enum.Parse(typeof(Day), "1").GetHashCode().ToString();
            var obj1 = Day.Day1.GetHashCode();
            var str = Day.Day1.GetHashCode().ToString();
            var st1r = Day.Day1.GetTypeCode().ToString();
        }
    }
    enum Day
    {
        Day1 = 122,
        Day2 = 2,
    }
}

