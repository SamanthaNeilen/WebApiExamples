using System;
using System.Globalization;
using System.Web;
using System.Web.Routing;
using Utilities;

namespace Framework.WebApiExample.Custom
{
    public class EmailRouteContraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            RouteParameterInputValidation(httpContext, route, parameterName, values);

            if (values.TryGetValue(parameterName, out var routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);
                return parameterValueString.IsEmail();
            }

            return false;
        }

        private void RouteParameterInputValidation(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values)
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

            if (parameterName == null)
            {
                throw new ArgumentNullException(nameof(parameterName));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
        }
    }
}