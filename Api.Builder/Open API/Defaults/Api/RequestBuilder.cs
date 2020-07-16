using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class RequestBuilder : ApiBuilder<EndpointInfo, RequestInfo>
    {
        protected internal override RequestInfo CreateValue(EndpointInfo endpoint, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var request = new RequestInfo();

            request.Parameters.Add(new OpenApiParameter
            {
                Name = "api-version",
                In = ParameterLocation.Header,
                Description = "API version.",
                Schema = new OpenApiSchema {Type = "string", Default = new OpenApiString(endpoint.Method.ApiVersion().ToString())},
                Required = true
            });
            
            foreach (var parameter in endpoint.Method.GetParameters())
            {
                var bindingSource = parameter.BindingSource();
                var schema = parameter.CreateSchema(schemaRegistry);

                if (bindingSource == BindingSource.Body)
                {
                    request.RequestBody = new OpenApiRequestBody
                    {
                        Content = new Dictionary<string, OpenApiMediaType>
                        {
                            [MediaType] = new OpenApiMediaType
                            {
                                Schema = schema
                            }
                        },
                        Description = parameter.Description(),
                        Required = parameter.Required()
                    };
                }
                else if (TryGetParameterLocation(bindingSource, out var parameterLocation))
                {
                    request.Parameters.Add(new OpenApiParameter
                    {
                        Name = parameter.Name(),
                        Description = parameter.Description(),
                        Required = parameter.Required(),
                        In = parameterLocation,
                        Schema = schema
                    });
                }
            }

            return request;
        }

        private static bool TryGetParameterLocation(BindingSource bindingSource, out ParameterLocation parameterLocation)
        {
            if (bindingSource == BindingSource.Header)
            {
                parameterLocation = ParameterLocation.Header;
                return true;
            }

            if (bindingSource == BindingSource.Path)
            {
                parameterLocation = ParameterLocation.Path;
                return true;
            }

            if (bindingSource == BindingSource.Query)
            {
                parameterLocation = ParameterLocation.Query;
                return true;
            }

            parameterLocation = default;
            return false;
        }
    }
}