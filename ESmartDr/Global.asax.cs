using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ESmartDr
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    var action = new StackTrace(exception).GetFrames().FirstOrDefault(f => typeof(IController).IsAssignableFrom(f.GetMethod().DeclaringType)).GetMethod();
        //    var ControllerName = (action.DeclaringType.FullName.Substring(action.DeclaringType.FullName.LastIndexOf("."))).Replace('.', ' ');
        //    var ActionMethod = action.ToString().Substring(action.ToString().LastIndexOf(" "));
        //    Server.ClearError();
        //    Response.Redirect("/Home/Error");
        //}
    }
}
