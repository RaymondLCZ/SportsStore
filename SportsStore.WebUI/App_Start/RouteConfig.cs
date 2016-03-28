using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new { controller = "Product", action = "List", category = (String)null, page = 1 });

            routes.MapRoute(null, "Page{page}",
                new { controller = "Product", action = "List", category = (String)null }, 
                new { page = @"\d+" });

            routes.MapRoute(null, "{Category}",
                new { controller = "Product", action = "List", page = 1 });

            routes.MapRoute(null, "{Category}/Page{page}",
                new { controller = "Product", action = "List" },
                new { page = @"\d+" });

            routes.MapRoute(null,"{controller}/{action}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //);
            // 實際上 product controller 類別的名字是 ProductController, 但在這裡只需要寫上 product 即可 
            // 順序很重要


        }
    }
}
