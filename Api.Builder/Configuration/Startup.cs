using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using static Api.Builder.Session;


namespace Api.Builder
{
    public class Startup
    {
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options => options.EnableEndpointRouting = false).AddApplicationPart(Assembly);
            services.AddApiVersioning(options =>
            {
                options.UseApiBehavior = false;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddControllers(options => options.Filters.Add(new ErrorFilter())).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            Configure(Assembly.GetApiInfo(), applicationBuilder);
        }

        protected virtual void Configure(ApiInfo api, IApplicationBuilder applicationBuilder)
        {
            ConfigureUserInterface(api, applicationBuilder);
            ConfigureRoutes(api, applicationBuilder);
        }

        private static void ConfigureUserInterface(ApiInfo api, IApplicationBuilder applicationBuilder)
        {
            var userInterface = new UserInterface(Path);

            foreach (var document in api.GetDocuments())
            {
                userInterface.AddOpenApiDocument(document);
            }

            userInterface.ConfigureApplication(applicationBuilder);
        }

        private static void ConfigureRoutes(ApiInfo api, IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMvc(configureRoutes =>
            {
                var name = 0;

                foreach (var route in api.GetRoutes())
                {
                    configureRoutes.MapRoute($"{name++}", route.Template, route.Defaults);
                }
            });
            applicationBuilder.UseRouting();
            applicationBuilder.UseEndpoints(builder => builder.MapControllers());
        }
    }
}