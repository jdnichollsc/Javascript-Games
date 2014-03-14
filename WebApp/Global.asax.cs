using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // La agrupación y minificación permiten reducir el número de Peticiones HTTP al combinar archivos individuales (CSS y JS) en un solo archivo y reducir el tamaño de los mismos.
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
