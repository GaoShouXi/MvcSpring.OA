using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.DAL
{
  public partial  class DbContextFactory
    {
      public static DbContext GetCurrentContext()
      {
          DbContext db = CallContext.GetData("DbContext") as DbContext;
         
          if (db == null)
          {
              db = new DataModelContainer();
              CallContext.SetData("DbContext",db);
          }
          return db;
      }
  
    }
}
