using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.WebApiExample.MiddleWare.Swagger
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            ValidateInput(operation, context);
            if (IsMethodWithHttpGetAttribute(context))
            {
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "extra",
                    In = "query",
                    Description = "This is an extra querystring parameter",
                    Required = false,
                    Type = "string"
                });

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "Used for certain authorization policies such as Bearer token authentication",
                    Required = false,
                    Type = "string"
                });
            }
        }

        private void ValidateInput(Operation operation, OperationFilterContext context)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
        }

        private bool IsMethodWithHttpGetAttribute(OperationFilterContext context)
        {
            return context.MethodInfo.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(HttpGetAttribute));
        }
    }
}
