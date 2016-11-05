using MvcSpring.OA.IBLL;
using MvcSpring.OA.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class UserInfoController : BaseController
    {
        short delflagNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
        //
        //// GET: /UserInfo/
        //UserInfoService UserInfoService = new UserInfoService();
        public IUserInfoService UserInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }
        public IActionInfoService ActionInfoService { get; set; }
        public IR_UserInfo_ActionInfoService R_UserInfo_ActionInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllUsers()
        {

           
            ViewData.Model = UserInfoService.GetEntites(a => a.DelFlag == delflagNormal).ToList();
         
            return View();
            
          
            
        }
        public ActionResult GetCount()
        { 
            int total=0;
            List<UserInfo> list = UserInfoService.GetEntitesByPage(1, 10, out total, u => u.Id == u.Id, u => u.Id, true).ToList();
            return Json(total,JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUser(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("异常的删除id提交");
            }
            string[] strIds = ids.Split(',');
            List<int> idList = new List<int>();
            foreach (var strId in strIds)
            {
                idList.Add(int.Parse(strId));
            }
            // UserInfoService.DeleteList(idList);
           int res= UserInfoService.DeleteList(idList);
           if (res > 0)
           {
               return Content("ok");
           }
           else
           {
               return Content("");
           }
        }
        public ActionResult Add(UserInfo userInfo)
        {
            userInfo.Modfiedon = DateTime.Now.ToString();
            userInfo.SubTime = DateTime.Now.ToString();
            userInfo.DelFlag = (Int32)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
            UserInfoService.Add(userInfo);
            return Content("ok");
           
        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = UserInfoService.GetEntites(u=>u.Id==id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditPost(int id,string username,string password,string remark)
        {
            
            UserInfo userInfo = UserInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            userInfo.Id = id;
            userInfo.UserName = username;
            userInfo.PassWord = password;
            userInfo.Remark = remark;
            
            userInfo.Modfiedon = DateTime.Now.ToString();
            
            UserInfoService.Update(userInfo);
            return Content("ok");
        }
        public ActionResult Find(int id)
        {
          UserInfo userInfo=  UserInfoService.GetEntites(u=>u.Id==id).FirstOrDefault();
            List<UserInfo> list=new List<UserInfo>();
            list.Add(userInfo);
            return Json(list, JsonRequestBehavior.AllowGet);
           
        }
      

    }
}
