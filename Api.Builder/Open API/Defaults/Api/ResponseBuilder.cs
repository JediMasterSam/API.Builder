using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class ResponseBuilder : ApiBuilder<EndpointInfo, OpenApiResponses>
    {
        protected internal override OpenApiResponses CreateValue(EndpointInfo endpoint, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var responses = new OpenApiResponses();

            foreach (var response in endpoint.Method.Responses())
            {
                var schema = response.Type.CreateSchema(schemaRegistry);
                
                responses[response.StatusCode.ToString()] = new OpenApiResponse
                {
                    Description = schema.Description,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        [MediaType] = new OpenApiMediaType
                        {
                            Schema = schema
                        }
                    }
                };
            }

            return responses;
        }
    }
}