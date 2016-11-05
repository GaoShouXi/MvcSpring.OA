using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.Common
{
   public partial class Log4NetWriter:ILogWriter
    {

        public void WriteLogInfo(string txt)
        {
            ILog logWriter = log4net.LogManager.GetLogger("Demo");
            logWriter.Error(txt);
        }
    }
}
