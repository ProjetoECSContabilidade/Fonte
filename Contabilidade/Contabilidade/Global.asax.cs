using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contabilidade
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string JobCacheAction = "http://localhost:2027/Home/AddJobCache";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);


            //BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            // Database.SetInitializer<ConexaoSQLServerContext>(null);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Cache["jobkey"] == null)
            {
                HttpContext.Current.Cache.Add("jobkey", "jobvalue", null, DateTime.MaxValue, TimeSpan.FromHours(12), CacheItemPriority.Default, JobCacheRemoved);
            }
        }

        protected static void JobCacheRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            var client = new WebClient();
            client.DownloadData(JobCacheAction);
            ScheduleJob();
        }

        private static void ScheduleJob()
        {
            //CallJob callJobClass = new CallJob();
            CallJob.Execute();
        }
    }
}