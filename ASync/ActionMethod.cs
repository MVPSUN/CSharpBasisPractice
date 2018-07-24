using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASync
{
    public class ActionMethod
    {
        public static Action<Exception> GetTaskAction(Action<Exception> action)
        {
            return new Action<Exception>((e) =>
            {
                try
                {
                    action(e);
                }
                catch (Exception err)
                {
                }
            });
        }

    }
}
