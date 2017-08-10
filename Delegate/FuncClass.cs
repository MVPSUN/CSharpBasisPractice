using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class FuncClass
    {
        public void Test()
        {
            Action<int> action1 = new Action<int>(MyMethodC);
            action1(1);
            Func<int> func1 = MyMethodA;
            var resultFunc1 = func1();
            Func<int> func2 = MyMethodB;
            var resultFunc2 = func2();
            FunList(func1, func2);
            FunList(func2);

            //2.  
            //  MyMethodB<string>(new Func<string, int>(MyMethodA), "feige");

            //3  
            // MyMethodB(new Func<string, int>(MyMethodA), "feige");
        }
        public int MyMethodA()
        {
            var str = "";
            if (string.IsNullOrEmpty(str))
                return 0;
            return 1;
        }
        public int MyMethodB()
        {
            var str = "";
            if (string.IsNullOrEmpty(str))
                return 11110000;
            return 11111;
        }
        public void MyMethodC(int str)
        {
        }
        public void FunList(params Func<int>[] func)
        {
            var tt = func.Select(s => s());
        }
        public void FunListParam(params List<string>[] func)
        {

        }
    }

}
