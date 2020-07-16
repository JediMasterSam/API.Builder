using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using static System.IO.File;
using static System.IO.Path;

namespace Api.Builder
{
    internal static class JsonWriter
    {
        internal static void ToJson(this OpenApiDocument document, string path)
        {
            using var stringWriter = new StringWriter();

            document.SerializeAsV3(new OpenApiJsonWriter(stringWriter));
            WriteAllText(Combine(path, $"{document.Info.Title.Replace(" ", "_")}-{document.Info.Version}.json"), stringWriter.ToString());
        }
    }
}