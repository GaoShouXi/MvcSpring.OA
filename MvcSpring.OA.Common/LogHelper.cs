using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvcSpring.OA.Common
{
   public partial class LogHelper
    {
       public static Queue<string> ExceptionStringQueue = new Queue<string>();
       public static List<ILogWriter> LogWriterList = new List<ILogWriter>();
       static LogHelper()
       {
           LogWriterList.Add(new Log4NetWriter());
           ThreadPool.QueueUserWorkItem(o =>
               {
                   lock (ExceptionStringQueue)
                   {
                       if (ExceptionStringQueue.Count() > 0)
                       {
                           string str = ExceptionStringQueue.Dequeue();
                           foreach (var logWriter in LogWriterList)
                           {
                               logWriter.WriteLogInfo(str);
                           }
                       }
                       else
                       {

                           Thread.Sleep(30);
                       }
                   }
               });
               
       }
       public static void WriteLog(string exceptionText)
       {
           lock (ExceptionStringQueue)
           {
               ExceptionStringQueue.Enqueue(exceptionText);
               if (ExceptionStringQueue.Count() > 100)//当队列拥挤值到100
               { 
                 //就写一次
               }

           }
       }
    }
}
