using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    public class ConsoleOutput_First : IOutput, IDateWriter
    {
        public void Write(string content)
        {
            Console.WriteLine("ConsoleOutput_First");
        }

        public void WriteDate()
        {
            Console.WriteLine("ConsoleOutput_First");
        }
    }
}
