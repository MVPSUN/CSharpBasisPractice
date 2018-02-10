using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {

            var methodResult = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            var methodResult1 = MethodBase.GetCurrentMethod();
            var instance = new { action = "Index", id = "eecc", dd = "dd" };
            Type type = instance.GetType();
            IEnumerable<PropertyInfo> properties_First = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                                     ;
            IEnumerable<PropertyInfo> properties_Second = type.GetProperties();

            IEnumerable<PropertyInfo> properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                                      .Where(prop => prop.GetIndexParameters().Length == 0 &&
                                                                     prop.GetMethod != null);
        }
    }
}
