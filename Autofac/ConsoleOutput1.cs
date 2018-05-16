using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    public class ConsoleOutput1 : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine("1111");
        }
    }
}
