using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA.Models
{
    public partial class MyExceptionLog:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Common.LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}