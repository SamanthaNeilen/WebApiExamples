using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.WebApiExample.MiddleWare;
using NetCore.WebApiExample.MiddleWare.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetCore.WebApiExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.ConstraintMap.Add("Email", typeof(EmailRouteContraint));
            });

            ConfigureSwagger(services); // contains the services.AddSwaggerGen(options => {...} ) code see method definition below

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'V'VVV");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // Notice you need to add the IApiVersionDescriptionProvider to the method signature!
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                foreach (var apiVersion in provider.ApiVersionDescriptions.OrderBy(version => version.ToString()))
                {
                    c.SwaggerEndpoint(
                        $"/swagger/{apiVersion.GroupName}/swagger.json",
                         $"NetCore.WebApiExample {apiVersion.GroupName}"
                    );
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var apiVersion in provider.ApiVersionDescriptions)
                {
                    ConfigureVersionedDescription(options, apiVersion);
                }

                var xmlCommentsPath = Assembly.GetExecutingAssembly().Location.Replace("dll", "xml");
                options.IncludeXmlComments(xmlCommentsPath);

                options.OperationFilter<SwaggerOperationFilter>();
                options.DocumentFilter<SwaggerDocumentFilter>();
            });
        }

        
        private void ConfigureVersionedDescription(SwaggerGenOptions options, ApiVersionDescription apiVersion)
        {
            //In production code you should probably use a seperate class to get these version descriptions
            var dictionairy = new Dictionary<string, string> 
            {
                { "1.0", "This API features several endpoints showing different API features for API version V1" },
                { "2.0", "This API features several endpoints showing different API features for API version V2" }
            };

            var apiVersionName = apiVersion.ApiVersion.ToString();
            options.SwaggerDoc(apiVersion.GroupName,
                new Info()
                {
                    Title = "NetCore.WebApiExample",
                    Version = apiVersionName,
                    Description = dictionairy[apiVersionName] 
                });
        }
    }
}
