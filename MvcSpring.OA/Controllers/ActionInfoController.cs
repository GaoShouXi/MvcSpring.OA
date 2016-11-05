using MvcSpring.OA.IBLL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class ActionInfoController : BaseController
    {
        short delflagNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
        //
        // GET: /ActionInfo/
        public IActionInfoService ActionInfoService { get; set; }
        public IUserInfoService UserInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }
        public ActionResult Index()
        {
            ViewData.Model = ActionInfoService.GetEntites(a => a.DelFlag == delflagNormal).ToList();
            return View();
        }
              
            
        
        public ActionResult GetCount()
        { 
            int total=0;
            List<ActionInfo> list = ActionInfoService.GetEntitesByPage(1, 10, out total, u => u.Id == u.Id, u => u.Id, true).ToList();
            return Json(total,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(string ids)
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
           int res= ActionInfoService.DeleteList(idList);
           if (res > 0)
           {
               return Content("ok");
           }
           else
           {
               return Content("");
           }
        }
        public ActionResult Add(ActionInfo actionInfo)
        {
            actionInfo.Modfiedon = DateTime.Now.ToString();
            actionInfo.SubTime = DateTime.Now.ToString();
            actionInfo.DelFlag = delflagNormal;
            actionInfo.IsMenu = Request["IsMenu"] == "true" ? true : false;
            ActionInfoService.Add(actionInfo);
            return Content("ok");
           
        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = ActionInfoService.GetEntites(u=>u.Id==id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditPost(int id,string actionname,string remark,string httpmethod,string url,string ismenu,string sort,string menuicon)
        {
            
            ActionInfo actionInfo = ActionInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            actionInfo.Id = id;
            actionInfo.ActionName = actionname;
            actionInfo.HttpMethod = httpmethod;
            actionInfo.Url = url;
            actionInfo.IsMenu = Convert.ToBoolean(ismenu);
            actionInfo.Sort = Convert.ToInt32(sort);
            actionInfo.Remark = remark;
            
            actionInfo.Modfiedon = DateTime.Now.ToString();
            actionInfo.MenuIcon = menuicon;
            

            ActionInfoService.Update(actionInfo);
            return Content("ok");
        }
        public ActionResult Find(int id)
        {
          ActionInfo actionInfo=  ActionInfoService.GetEntites(u=>u.Id==id).FirstOrDefault();
            List<ActionInfo> list=new List<ActionInfo>();
            list.Add(actionInfo);
            return Json(list, JsonRequestBehavior.AllowGet);
           
        }
        public ActionResult UploadImage()
        {
            var file = Request.Files["fileMenuIcon"];
            string path = "/UploadFiles/UploadImgs" + Guid.NewGuid().ToString() + "-" + file.FileName;
            file.SaveAs(Request.MapPath(path));
            return Content(path);

        }
        public ActionResult UploadImage1()
        {
            var file = Request.Files["fileMenuIcon1"];
            string path = "/UploadFiles/UploadImgs" + Guid.NewGuid().ToString() + "-" + file.FileName;
            file.SaveAs(Request.MapPath(path));
            return Content(path);

        }


    }
}
