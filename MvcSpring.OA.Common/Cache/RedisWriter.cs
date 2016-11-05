using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSpring.OA.Common.Cache
{
   public partial class RedisWriter
    {
       private RedisClient redisClient;
       public RedisWriter()
       { 
          string strAppRedisServer=System.Configuration.ConfigurationManager.AppSettings["RedisServerList"];
          string[] servers = strAppRedisServer.Split(',');
          foreach (var item in servers)
          {
             string   [] hostandport= item.Split(',');
             string host = hostandport[0];
             int port = Convert.ToInt32(hostandport[1]);
             redisClient = new RedisClient(host ,port);
          }

       }
       public void AddCache(string key, object value, DateTime expDate)
       {
           redisClient.Add(key, value, expDate);
       }

       public void AddCache(string key, object value)
       {
           redisClient.Add(key, value);
       }

       public object GetCache(string key)
       {
           return redisClient.Get(key);
       }

       //public T GetCache<T>(string key)
       //{

       //  //  return (T)redisClient.Get(key);
       //}


       public void SetCache(string key, object value, DateTime extDate)
       {
           redisClient.Set(key, value, extDate);
       }

       public void SetCache(string key, object value)
       {
           redisClient.Set(key, value);
       }
    }
}
