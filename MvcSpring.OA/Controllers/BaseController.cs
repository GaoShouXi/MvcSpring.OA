using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class BaseController : Controller
    {
        public bool IsCheckedUserLogin = true;
        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (IsCheckedUserLogin)
            {
                //使用memecached +cookie
                if (Request.Cookies["userLoginId"] == null) // if (filterContext.HttpContext.Session["loginUser"] == null)如果是Session
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    return;
                }
                string userGuid = Request.Cookies["userLoginId"].Value;
                UserInfo userInfo = Common.Cache.CacheHelper.GetCache(userGuid) as UserInfo;
                if (userInfo == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    return;
                }
                LoginUser = userInfo;
                //滑动窗口机制，每访问站内新页面刷新cookies缓存时间
                Common.Cache.CacheHelper.SetCache(userGuid, userInfo, DateTime.Now.AddMinutes(20));
            }
        }
    }
}