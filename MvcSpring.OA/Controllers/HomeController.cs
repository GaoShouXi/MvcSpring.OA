using MvcSpring.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Controllers
{
    public class HomeController : BaseController
    {
        short delflagNormal = (short)MvcSpring.OA.Model.Enum.DelFlagEnum.Normal;
        //
        // GET: /Home/
        public IUserInfoService UserInfoService { get; set; }
        public IActionInfoService ActionInfoService { get; set; } 
        public ActionResult Index()
        {
            return View();
        }

    }
}
