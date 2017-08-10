using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    /// <summary>
    /// 
    /// 注意事项：
    /// 1，抽象类是对类的抽象；接口是对行为的抽象；
    /// 2，抽象方法必须被重写，虚方法可以被重写也可以不被重写，两者约束规则不同
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 多态
            Animal dog = new Dog();
            dog.Cry();
            Animal cat = new Cat();
            cat.Cry();
            cat.Run();
            #endregion
        }
    }

    #region OverLoad
    /// <summary>
    /// 重载：参数个数不同可以构成重载，单独修改返回值不能构成方法的重载
    /// </summary>
    public class OverLoad
    {
        public int OverLoadFunc(int a, int b)
        {
            return 0;
        }
        public void OverLoadFunc(int a, int b, int c)
        {
        }
    }
    #endregion

    #region Abstract
    public abstract class Animal
    {
        string annimal = "";
        public Animal()
        { }
        public Animal(string param)
        {
            annimal = param;

        }
        public abstract void Cry();
        public virtual void Run()
        {
            Console.WriteLine("父类");
        }
    }
    public class Cat : Animal
    {
        public Cat() : base("Animal带参数构造函数!")
        {
            Console.WriteLine("Cat构造函数");
        }
        public override void Cry()
        {

        }

        public override void Run()
        {
            base.Run();
        }

    }
    public class Dog : Animal
    {
        public override void Cry()
        {

        }

        public override void Run()
        {
            Console.WriteLine("子类");
        }

    }
    #endregion
}
