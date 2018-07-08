using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleOutput>().As<IOutput>().PreserveExistingDefaults();
            //builder.RegisterType<ConsoleOutput_First>().As<IOutput>();//以IOutput形式来调用和以ConsoleOutput_First自身形式来调用
            //builder.RegisterType<ConsoleOutput_First>().AsSelf();//以ConsoleOutput_First自身形式来调用
            //builder.RegisterType<ConsoleOutput_First>().AsImplementedInterfaces();//以类ConsoleOutput_First实现的接口IOutput和IDateWriter进行注册
            builder.RegisterType<ConsoleOutput_First>().AsSelf().AsImplementedInterfaces().SingleInstance();
            Container = builder.Build();
            WriteDate();
        }
        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var consoleOutput_First = scope.Resolve<ConsoleOutput_First>();
                var consoleOutput_Interface = scope.Resolve<IOutput>();
                var consoleOutput_First_Writer = scope.Resolve<IDateWriter>();
                consoleOutput_First.Write("test1");
                consoleOutput_Interface.Write("test2");
                consoleOutput_First_Writer.WriteDate();
                //var output = scope.Resolve<IOutput>();
                //output.Write("ddd");
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();


            }
        }
    }
}
