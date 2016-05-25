using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMusica.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Artistas",
                url: "tienda/{nombre}/{action}/",
                defaults: new { controller = "Artistas", action = "Albums", nombre = String.Empty }
            );

            routes.MapRoute(
                name: "Albums",
                url: "admin/{nombreArtista}/{nombreAlbum}/{action}/",
                defaults: new { controller = "Albums", action = "Editar", nombreArtista = String.Empty, nombreAlbum = String.Empty }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
