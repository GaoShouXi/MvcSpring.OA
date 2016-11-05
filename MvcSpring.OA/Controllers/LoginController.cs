using MvcSpring.OA.Common;
using MvcSpring.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
  
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public IUserInfoService UserInfoService{get;set;}
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new ValidateCode();
            string strCode = validateCode.CreateValidateCode(4);
            Session["VCode"] = strCode;
            byte[] imgBytes = validateCode.CreateValidateGraphic(strCode);
            return File(imgBytes,@"image/jpeg");
        }
        #region 登录基础验证
        public ActionResult BaseLogin()
        { 
          string strCode=Request["vcode"];
          string sessionCode = Session["VCode"] as string;//用了验证码
          Session["VCode"] = null;//清空session防止多次登录
          if (string.IsNullOrEmpty(sessionCode))
          {
              return Content("验证码错误");
          }
          if (sessionCode != strCode)
          {
              return Content("验证码错误");
          }
          string username = Request["username"];
            string pwd =Request["userpwd"];
            short delNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
            var userInfo = UserInfoService.GetEntites(u=>u.DelFlag==delNormal&&u.UserName==username&&u.PassWord==pwd).FirstOrDefault();
            if (userInfo == null)
            {
                return Content("用户密码错误");
            }
            string userLoginId = Guid.NewGuid().ToString();
            Common.Cache.CacheHelper.AddCache(userLoginId, userInfo, DateTime.Now.AddMinutes(20));
            Response.Cookies["userLoginId"].Value = userLoginId;
            return Content("ok");
          

        
        }
        #endregion

    }
}
