using MvcSpring.OA.IBLL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        short delflagNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
        public IDepartmentService DepartmentService { get; set; }
        public IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            ViewData.Model = DepartmentService.GetEntites(a => a.DelFlag == delflagNormal).ToList();
            return View();
        }
        public ActionResult GetCount()
        {
            int total = 0;
            List<Department> list = DepartmentService.GetEntitesByPage(1, 10, out total, u => u.Id == u.Id, u => u.Id, true).ToList();
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
            int res = DepartmentService.DeleteList(idList);
            if (res > 0)
            {
                return Content("ok");
            }
            else
            {
                return Content("");
            }
        }
        public ActionResult Add(Department departmentInfo)
        {
           
            departmentInfo.SubTime = DateTime.Now.ToString();
            departmentInfo.DelFlag = (Int32)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
            departmentInfo.Modifedon = DateTime.Now.ToString();
         
            DepartmentService.Add(departmentInfo);
            return Content("ok");

        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = DepartmentService.GetEntites(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditPost(int id, string departmentname, string description)
        {

            Department departmentInfo = DepartmentService.GetEntites(u => u.Id == id).FirstOrDefault();
            departmentInfo.Id = id;
            departmentInfo.DepartmentName = departmentname;
            departmentInfo.Modifedon = DateTime.Now.ToString();
            
            departmentInfo.Description = description;

            

            DepartmentService.Update(departmentInfo);
            return Content("ok");
        }
        public ActionResult Find(int id)
        {
            Department departmentInfo = DepartmentService.GetEntites(u => u.Id == id).FirstOrDefault();
            List<Department> list = new List<Department>();
            list.Add(departmentInfo);
            return Json(list, JsonRequestBehavior.AllowGet);

        }

    }
}
