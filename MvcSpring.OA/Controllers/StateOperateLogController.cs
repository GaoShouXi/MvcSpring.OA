using MvcSpring.OA.IBLL;
using MvcSpring.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class StateOperateLogController : Controller
    {
        //
        // GET: /StateOperateLog/
        short delflagNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
        public IStateOperateLogService StateOperateLogService { get; set; }
        public ActionResult Index()
        {
            ViewData.Model = StateOperateLogService.GetEntites(u=>u.Id==u.Id);
            return View();
        }
        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("异常的删除id提交");
            }
            int id = Convert.ToInt32(ids);
            StateOperateLog stateoperatelogInfo = StateOperateLogService.GetEntites(u => u.Id == id).FirstOrDefault();

            // UserInfoService.DeleteList(idList);
            bool res = StateOperateLogService.Delete(stateoperatelogInfo);

            return Content("ok");
        }


    }
}
