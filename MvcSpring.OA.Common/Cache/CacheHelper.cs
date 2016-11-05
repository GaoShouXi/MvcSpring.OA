using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.Common.Cache
{
  public partial  class CacheHelper
    {
      public static ICacheWriter CacheWriter { get; set; }
      static CacheHelper()
      {
          IApplicationContext ctx = ContextRegistry.GetContext();//这是Spring支持的得到Context的方式
          //ctx.GetObject("CacheHelper");
          CacheHelper.CacheWriter = ctx.GetObject("CacheWriter") as ICacheWriter;
      }
      public static void AddCache(string key, object value, DateTime expDate)
      {

          CacheWriter.AddCache(key, value, expDate);
      }
      public static void AddCache(string key, object value)
      {
          CacheWriter.AddCache(key, value);
      }

      public static object GetCache(string key)
      {
          return CacheWriter.GetCache(key);
      }
      public static void SetCache(string key, object value, DateTime ext)
      {
          CacheWriter.SetCache(key, value, ext);
      }
      public static void SetCache(string key, object value)
      {
          CacheWriter.SetCache(key, value);
      }
    }
}
