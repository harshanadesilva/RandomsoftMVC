using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MytestApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            TimeSpan ShiftStart = new TimeSpan(9, 30, 0);
            TimeSpan ShiftEnd = new TimeSpan(22, 0, 0);
            var src = DateTime.Now;
            TimeSpan timenow = new TimeSpan(src.Hour, src.Minute, 0);

            if ((ShiftStart > ShiftEnd && (timenow > ShiftStart || timenow < ShiftEnd)) || (timenow > ShiftStart && timenow < ShiftEnd))
            {
                Console.Write("Yes You are in shift!");
            }
            else
            {
                Console.Write("Out of shift!");
            }
        }
    }
}
