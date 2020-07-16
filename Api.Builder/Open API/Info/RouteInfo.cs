using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using static Microsoft.OpenApi.OpenApiSpecVersion;

namespace Api.Builder
{
    public sealed class RouteInfo
    {
        internal RouteInfo(ControllerInfo controller, EndpointInfo action, OpenApiOperation operation)
        {
            var path = $"/{controller.Name}/{action.Name}";
            var template = $"{{{nameof(controller)}}}/{{{nameof(action)}}}";
            var defaults = new Dictionary<string, string> {{nameof(controller), controller.Name}, {nameof(action), action.Name}};

            foreach (var parameter in operation.Parameters.Where(request => request.In == ParameterLocation.Path))
            {
                var segment = $"/{{{parameter.Name}}}";

                path += segment;
                template += segment;

                if (parameter.Required || parameter.Schema.Default == null) continue;

                using var stringWriter = new StringWriter();

                parameter.Schema.Default.Write(new OpenApiJsonWriter(stringWriter), OpenApi3_0);
                defaults[parameter.Name] = stringWriter.ToString();
            }

            Path = path;
            Template = template;
            Defaults = defaults.ToImmutableDictionary();
        }

        public string Path { get; }

        public string Template { get; }

        public ImmutableDictionary<string, string> Defaults { get; }
    }
}