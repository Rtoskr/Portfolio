using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StackExchange.Profiling;
using System.Diagnostics;

namespace Web
{
    public static class Globals
    {
        // This stopwatch is used for measuring time in ms that each page load takes.
        public static Stopwatch RequestTimer = new Stopwatch();
    }

    public class MvcApplication : HttpApplication
    {
        protected void Application_BeginRequest()
        {
            Globals.RequestTimer.Start();
        }

        protected void Application_EndRequest()
        {
            Globals.RequestTimer.Reset();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
