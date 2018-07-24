using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ASync.AttendanceTask
{
    /// <summary>
    /// Task类库
    /// </summary>
    public class AttendanceTask
    {
        private const int ConcurrencyLevel = 5;//最多开启线程数
        private static readonly TaskFactory factory;
        //   private static readonly Logging.LogWrapper logger = new LogWrapper();
        static AttendanceTask()
        {
            factory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(ConcurrencyLevel));
        }

        #region Task Factory
        public static Task AddTask(Action<object> action, object parameter, Action success, Action<Exception> failed)
        {
            return factory.StartNew(obj =>
            {
                try
                {
                    GetTaskAction(action)(obj);
                    GetTaskAction(success);
                }
                catch (Exception e)
                {
                    GetTaskAction(failed)(e);
                }

            }, parameter);
        }
        public static Task AddTask(Action action)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            return factory.StartNew(GetTaskAction(action), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public static Task AddTask(Action action, Action success, Action<Exception> failed)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            return factory.StartNew(() =>
            {
                try
                {
                    GetTaskAction(action)();
                    GetTaskAction(success)();
                }
                catch (Exception e)
                {
                    GetTaskAction(failed)(e);
                }

            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static Task AddAsyncTask(Action action, Action success, Action<Exception> failed)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            var result = factory.StartNew(() =>
             {
                 try
                 {
                     GetTaskAction(action)();
                     GetTaskAction(success)();
                 }
                 catch (Exception e)
                 {
                     GetTaskAction(failed)(e);
                 }

             }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            return Task.FromResult(result).Unwrap();

        }
        #endregion

        #region   Execute  Action
        private static Action<object> GetTaskAction(Action<object> action)
        {
            return new Action<object>((obj) =>
            {
                try
                {
                    action(obj);
                }
                catch (Exception err)
                {
                    //  logger.Info(new AttendanceTaskException("AttendanceTask action err,errormessage:" + err.Message));
                }
            });
        }
        private static Action GetTaskAction(Action action)
        {
            return new Action(() =>
            {
                try
                {
                    action();
                }
                catch (Exception err)
                {
                    //  logger.Info(new AttendanceTaskException("AttendanceTask action err,errormessage:" + err.Message));
                }
            });
        }
        private static Action<Exception> GetTaskAction(Action<Exception> action)
        {
            return new Action<Exception>((e) =>
            {
                try
                {
                    action(e);
                }
                catch (Exception err)
                {
                    //   logger.Info(new AttendanceTaskException("AttendanceTask action err,errormessage:" + err.Message));
                }
            });
        }
        #endregion

        #region Task Run
        public static Task Run(Action action)
        {
            var context = HttpContext.Current;

            var allRolesTask = Task.Run(() =>
            {
                HttpContext.Current = context;

                action();
            });
            return allRolesTask;
        }
        public static Task<TResult> Run<TResult>(Func<TResult> action)
        {
            var context = HttpContext.Current;

            var allRolesTask = Task.Run(() =>
            {
                HttpContext.Current = context;

                return action();
            });
            return allRolesTask;
        }
        #endregion

    }
    internal class AttendanceTaskException : ApplicationException
    {
        public AttendanceTaskException()
        {
        }

        public AttendanceTaskException(String message)
            : base(message)
        {
        }

        public AttendanceTaskException(String message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        protected AttendanceTaskException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
