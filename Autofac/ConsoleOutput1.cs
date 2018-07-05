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
            Console.WriteLine("1111");
        }

        public void WriteDate()
        {
            // throw new NotImplementedException();
        }
    }
}
