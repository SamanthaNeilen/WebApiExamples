using Framework.WebApiExample.Custom;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Framework.WebApiExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("Email", typeof(EmailRouteContraint));
            routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.MapRoute(
                name: "GetNumber",
                url: "GetNumber/{input}",
                defaults: new { controller = "Home", action = "GetNumber" },
                constraints: new { input = @"\d{1,3}" }
            );

            routes.MapRoute(
                name: "GetEmail",
                url: "GetEmail/{email}",
                defaults: new { controller = "Home", action = "GetEmail" },
                constraints: new { Email = new EmailRouteContraint() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
