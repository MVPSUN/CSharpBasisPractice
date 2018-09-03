using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var ss = System.Environment.CurrentDirectory;
            var s1 = System.IO.Directory.GetCurrentDirectory();
            var path = @"E:\PersonalCode\technology\technologyTest\SystemIOFile\Data\TextFile1.txt";
            var jsonStr = System.IO.File.ReadAllText(path);
            System.IO.File.WriteAllText(path, "1231231", Encoding.Default);
        }
    }
}
