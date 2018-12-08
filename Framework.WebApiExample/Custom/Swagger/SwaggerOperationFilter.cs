using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Framework.WebApiExample.Custom.Swagger
{
    public class SwaggerOperationFilter : IOperationFilter
    {      

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            ValidateInput(operation, schemaRegistry, apiDescription);
            if (IsMethodWithHttpGetAttribute(apiDescription))
            {
                operation.parameters.Add(new Parameter
                {
                    name = "extra",
                    @in = "query",
                    description = "This is an extra querystring parameter",
                    required = false,
                    type = "string"
                });

                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "Used for certain authorization policies such as Bearer token authentication",
                    required = false,
                    type = "string"
                });
            }
        }

        private bool IsMethodWithHttpGetAttribute(ApiDescription apiDescription)
        {
            var attributes = apiDescription.ActionDescriptor.GetCustomAttributes<HttpGetAttribute>();
            return attributes != null && attributes.Any();
        }

        private void ValidateInput(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (schemaRegistry == null)
            {
                throw new ArgumentNullException(nameof(schemaRegistry));
            }

            if (apiDescription == null)
            {
                throw new ArgumentNullException(nameof(apiDescription));
            }

            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
        }
    }
}
