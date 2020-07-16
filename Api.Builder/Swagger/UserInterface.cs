using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using static System.IO.Directory;
using static System.IO.Path;

namespace Api.Builder
{
    public sealed class UserInterface
    {
        private const string Swagger = "Swagger";

        public UserInterface(string path)
        {
            path = Combine(path, Swagger);

            if (Exists(path))
            {
                Delete(path, true);
            }

            CreateDirectory(path);

            Path = path;
        }

        private string Path { get; }

        public void AddOpenApiDocument(OpenApiDocument document)
        {
            document.ToJson(Path);
        }

        public void ConfigureApplication(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseDefaultFiles().UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path),
                RequestPath = $"/{Swagger}"
            });

            applicationBuilder.UseSwaggerUI(setupAction =>
            {
                setupAction.RoutePrefix = string.Empty;

                foreach (var file in GetFiles(Path))
                {
                    var fileName = GetFileNameWithoutExtension(file);
                    setupAction.SwaggerEndpoint($"/{Swagger}/{fileName}.json", fileName.Replace("-", " "));
                }
            });
        }
    }
}