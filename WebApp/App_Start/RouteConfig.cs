using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Games",
                 url: "juegos",
                 defaults: new { controller = "Games", action = "Index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "Developers",
                url: "desarrolladores",
                defaults: new { controller = "Developers", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AboutUs",
                url: "acercade",
                defaults: new { controller = "Home", action = "AboutUs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ContactUs",
                url: "contactenos",
                defaults: new { controller = "Home", action = "ContactUs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
