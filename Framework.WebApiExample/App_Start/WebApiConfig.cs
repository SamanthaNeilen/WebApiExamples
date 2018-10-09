using Framework.WebApiExample.Custom;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Framework.WebApiExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("Email", typeof(EmailHttpRouteConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
