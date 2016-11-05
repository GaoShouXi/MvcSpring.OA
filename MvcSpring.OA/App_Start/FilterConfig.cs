using MvcSpring.OA.Models;
using System.Web;
using System.Web.Mvc;

namespace MvcSpring.OA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionLog());
        }
    }
}