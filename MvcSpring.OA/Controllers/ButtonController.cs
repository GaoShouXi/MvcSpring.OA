using MvcSpring.OA.IBLL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class ButtonController : Controller
    {
        //
        // GET: /Button/
        
        public IButtonInfoService ButtonInfoService { get; set; }
        public ActionResult Index()
        {
            ViewData.Model = ButtonInfoService.GetEntites(b=>b.Id==b.Id).ToList();
            return View();
        }



        public ActionResult GetCount()
        {
            int total = 0;
            List<ButtonInfo> list = ButtonInfoService.GetEntitesByPage(1, 10, out total, u => u.Id == u.Id, u => u.Id, true).ToList();
            return Json(total, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("异常的删除id提交");
            }
            int id = Convert.ToInt32(ids);
            ButtonInfo buttonInfo = ButtonInfoService.GetEntites(u => u.Id == id).FirstOrDefault();

            // UserInfoService.DeleteList(idList);
            bool res = ButtonInfoService.Delete(buttonInfo);

            return Content("ok");
        }
        public ActionResult Add(ButtonInfo buttonInfo)
        {

            buttonInfo.AddDate = DateTime.Today;

            
            ButtonInfoService.Add(buttonInfo);
            return Content("ok");

        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = ButtonInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditPost(int id, string buttonname, string httpmethod,  string menuicon,string sort)
        {

            ButtonInfo buttonInfo = ButtonInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            buttonInfo.Id = id;
            buttonInfo.ButtonName = buttonname;
            buttonInfo.HttpMethod = httpmethod;
            
            
            buttonInfo.Sort = Convert.ToInt32(sort);
            
            buttonInfo.Icon = menuicon;




            ButtonInfoService.Update(buttonInfo);
            return Content("ok");
        }
        public ActionResult Find(int id)
        {
            ButtonInfo buttonInfo = ButtonInfoService.GetEntites(u => u.Id == id).FirstOrDefault();
            List<ButtonInfo> list = new List<ButtonInfo>();
            list.Add(buttonInfo);
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
