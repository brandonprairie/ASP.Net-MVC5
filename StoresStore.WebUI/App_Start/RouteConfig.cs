using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StoresStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* '/' - Lists the first page of products from all categories */

            routes.MapRoute(null, "", new
            {
                controller = "Product",
                action = "List",
                category = (string)null,
                page = 1
            });

            /* Page 2 - lists specified page (in this case, page 2) , showing items from all categories*/
            routes.MapRoute(null, "Page{page}", new
            {
                controller = "Product",
                action = "List",
                category = (string)null
            },
            new { page = @"\d+" });

            /* Shows first page of soccer page */
            routes.MapRoute(null, "{category}", new
            {
                controller = "Product",
                action = "List",
                page = 1
            });

            /* shows 2nd page of soccer page */
            routes.MapRoute(null, "{category}/Page{page}", new
            {
                controller = "Product",
                action = "List"
            },
            new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");
            
            /* next one */

            routes.MapRoute(name: null,
                            url: "Page{page}",
                            defaults: new
                            {
                                Controller = "Product",
                                action = "List"
                            });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                { controller = "Product",
                  action = "List",
                  id = UrlParameter.Optional
                }
            );
        }
    }
}
