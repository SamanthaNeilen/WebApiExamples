using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Web.Http.Routing;
using Utilities;

namespace Framework.WebApiExample.Custom
{
    public class EmailHttpRouteConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            RouteParameterInputValidation(request, route, parameterName, values);

            if (values.TryGetValue(parameterName, out var routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);
                return parameterValueString.IsEmail();
            }

            return false;
        }

        private void RouteParameterInputValidation(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values)
        {
            //validate input params  
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
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