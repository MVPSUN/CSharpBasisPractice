using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
         
            IFactory factory = FactoryContainer.factory;
            IWindow window = factory.MakeWindow();
            Console.WriteLine("创建 " + window.ShowInfo());
            IButton button = factory.MakeButton();
            Console.WriteLine("创建 " + button.ShowInfo());
            ITextBox textBox = factory.MakeTextBox();
            Console.WriteLine("创建 " + textBox.ShowInfo());

            Console.ReadLine();
        }
    }
    #region 工厂
    internal interface IFactory
    {
        IWindow MakeWindow();

        IButton MakeButton();

        ITextBox MakeTextBox();
    }
    internal interface IButton
    {
        String ShowInfo();
    }
    internal sealed class WindowsFactory : IFactory
    {
        public IWindow MakeWindow()
        {
            return new WindowsWindow();
        }

        public IButton MakeButton()
        {
            return new WindowsButton();
        }

        public ITextBox MakeTextBox()
        {
            return new WindowsTextBox();
        }
    }
    internal sealed class MacFactory : IFactory
    {
        public IWindow MakeWindow()
        {
            return new MacWindow();
        }

        public IButton MakeButton()
        {
            return new MacButton();
        }

        public ITextBox MakeTextBox()
        {
            return new MacTextBox();
        }
    }
    #endregion

    #region 实现
    /// <summary>
    /// 
    /// </summary>
    internal class MacTextBox : ITextBox
    {
        public string ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
    internal class MacWindow : IWindow
    {
        string IWindow.ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
    internal sealed class MacButton : IButton
    {
        public String Description { get; private set; }

        public MacButton()
        {
            this.Description = " Mac风格按钮";
        }

        public String ShowInfo()
        {
            return this.Description;
        }
    }
    internal class WindowsTextBox : ITextBox
    {
        public string ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
    internal class WindowsWindow : IWindow
    {
        public string ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
    internal sealed class WindowsButton : IButton
    {
        public String Description { get; private set; }

        public WindowsButton()
        {
            this.Description = "Windows风格按钮";
        }

        public String ShowInfo()
        {
            return this.Description;
        }
    }
    #endregion


    internal static class FactoryContainer
    {
        public static IFactory factory { get; private set; }

        static FactoryContainer()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.cnblogs.com/Config.xml");
            XmlNode xmlNode = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[0];

            if ("Windows" == xmlNode.Value)
            {
                factory = new WindowsFactory();
            }
            else if ("Mac" == xmlNode.Value)
            {
                factory = new MacFactory();
            }
            else
            {
                throw new Exception("Factory Init Error");
            }
        }
    }

}
