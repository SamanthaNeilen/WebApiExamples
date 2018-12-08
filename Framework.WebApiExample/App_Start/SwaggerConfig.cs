using Framework.WebApiExample;
using Framework.WebApiExample.Custom.Swagger;
using Swashbuckle.Application;
using System.Reflection;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Framework.WebApiExample
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c => {
                    c.SingleApiVersion("v1", "Framework.WebApiExample");

                    var xmlCommentsPath = Assembly.GetExecutingAssembly().CodeBase.Replace("DLL", "xml");
                    c.IncludeXmlComments(xmlCommentsPath);

                    c.OperationFilter<SwaggerOperationFilter>();
                    c.DocumentFilter<SwaggerDocumentFilter>();
                })
                .EnableSwaggerUi(c => { });
        }
    }
}
