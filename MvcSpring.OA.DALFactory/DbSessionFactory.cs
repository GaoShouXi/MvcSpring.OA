using MvcSpring.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.DALFactory
{
   public partial class DbSessionFactory
    {
       public static IDbSession GetCurrentDbSession()
       {
           IDbSession Db = CallContext.GetData("DbSession") as IDbSession;
           if (Db == null)
           {
               Db= new DbSession();
               CallContext.SetData("DbSession",Db);
           }
           return Db;

       }
    
    }
}
