using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;
using Utilities;

namespace NetCore.WebApiExample.MiddleWare
{
    public class EmailRouteContraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            RouteParameterInputValidation(httpContext, route, routeKey, values);

            if (values.TryGetValue(routeKey, out var routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);
                return parameterValueString.IsEmail();
            }

            return false;
        }

        private void RouteParameterInputValidation(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values)
        {
            //validate input params  
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (routeKey == null)
            {
                throw new ArgumentNullException(nameof(routeKey));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
        }
    }
}
