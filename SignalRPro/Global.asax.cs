using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SignalRPro.Migrations;

namespace SignalRPro
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected String SqlConnectionString { get; set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var context = new MyDbContext())
                SqlConnectionString = context.Database.Connection.ConnectionString;


            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Start(SqlConnectionString);
        }

        protected void Application_End()
        {
            if (!String.IsNullOrEmpty(SqlConnectionString))
                SqlDependency.Start(SqlConnectionString);
        }
    }
}
