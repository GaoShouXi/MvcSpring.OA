using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MvcSpring.OA.DALFactory
{
   public partial class StaticDALFactory
    {
        
       public static string assmeblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
    }
}
