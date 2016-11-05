using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.Common
{
   public partial interface ILogWriter
    {
       void WriteLogInfo(string txt);
    }
}
