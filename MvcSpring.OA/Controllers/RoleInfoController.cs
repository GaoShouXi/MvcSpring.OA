using MvcSpring.OA.IBLL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class RoleInfoController : BaseController
    {
        short delflagNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
        //
        // GET: /RoleInfo/
        public IRoleInfoService RoleInfoService { get; set; }
        //
        // GET: /RoleInfo/

        public ActionResult Index()
        {
            ViewData.Model = RoleInfoService.GetEntites(a => a.DelFlag == delflagNormal).ToList();
            return View();
        }
        public ActionResult GetCount()
        {
            int total = 0;
            List<RoleInfo> list = RoleInfoService.GetEntitesByPage(1, 10, out total, u => u.Id == u.Id, u => u.Id, true).ToList();
            return Json(total, JsonRequestBehavior.AllowGet);
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
            int res = RoleInfoService.DeleteList(idList);
            if (res > 0)
            {
                return Content("ok");
            }
            else
            {
                return Content("");
            }
        }
        public ActionResult Add(RoleInfo roleInfo)
        {
            roleInfo.Modfiedon = DateTime.Now.ToString();
            roleInfo.SubTime = DateTime.Now.ToString();
            roleInfo.DelFlag = (Int32)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
            RoleInfoService.Add(roleInfo);
            return Content("ok");

        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = RoleInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditPost(int id, string actionname, string remark)
        {

            RoleInfo roleInfo = RoleInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            roleInfo.Id = id;
            roleInfo.RoleName = actionname;

            roleInfo.Remark = remark;

            roleInfo.Modfiedon = DateTime.Now.ToString();

            RoleInfoService.Update(roleInfo);
            return Content("ok");
        }
        public ActionResult Find(int id)
        {
            RoleInfo roleInfo = RoleInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            List<RoleInfo> list = new List<RoleInfo>();
            list.Add(roleInfo);
            return Json(list, JsonRequestBehavior.AllowGet);

        }

    }
}
