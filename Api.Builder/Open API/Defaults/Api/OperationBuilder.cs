using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class OperationBuilder : ApiBuilder<EndpointInfo, OpenApiOperation>
    {
        protected internal override OpenApiOperation CreateValue(EndpointInfo endpoint, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            return new OpenApiOperation
            {
                Description = endpoint.Method.Description(),
                Deprecated = endpoint.Method.Deprecated()
            };
        }
    }
}