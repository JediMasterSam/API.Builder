using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public static class Api
    {
        private static ApiReader<Type, ControllerInfo> ControllerReader { get; set; } = new ControllerReader();

        private static ApiReader<MethodInfo, EndpointInfo> EndpointReader { get; set; } = new EndpointReader();

        private static ApiBuilder<ApiVersion, OpenApiInfo> InfoBuilder { get; set; } = new InfoBuilder();

        private static ApiBuilder<EndpointInfo, OpenApiOperation> OperationBuilder { get; set; } = new OperationBuilder();

        private static ApiBuilder<EndpointInfo, RequestInfo> RequestBuilder { get; set; } = new RequestBuilder();

        private static ApiBuilder<EndpointInfo, OpenApiResponses> ResponseBuilder { get; set; } = new ResponseBuilder();

        private static ApiBuilder<ControllerInfo, IList<OpenApiTag>> TagBuilder { get; set; } = new TagBuilder();

        public static ApiInfo GetApiInfo(this Assembly assembly)
        {
            var apiInfo = new ApiInfo();

            foreach (var controllerGroup in ControllerReader.GetValues(assembly.GetTypes()).GroupBy(controller => controller.ApiVersion))
            {
                var paths = new OpenApiPaths();
                var schemaRegistry = new Dictionary<string, OpenApiSchema>();

                foreach (var controller in controllerGroup)
                {
                    var tags = TagBuilder.CreateValue(controller, schemaRegistry);

                    foreach (var endpoint in EndpointReader.GetValues(controller.Type.Methods()))
                    {
                        var operation = OperationBuilder.CreateValue(endpoint, schemaRegistry);
                        var requestInfo = RequestBuilder.CreateValue(endpoint, schemaRegistry);
                        var responses = ResponseBuilder.CreateValue(endpoint, schemaRegistry);

                        operation.Tags = tags;
                        operation.Parameters = requestInfo.Parameters;
                        operation.RequestBody = requestInfo.RequestBody;
                        operation.Responses = responses;

                        paths[apiInfo.AddRoute(controller, endpoint, operation).Path] = new OpenApiPathItem
                        {
                            Description = $"{controller.Name}/{endpoint.Name}",
                            Operations = new Dictionary<OperationType, OpenApiOperation>
                            {
                                [endpoint.OperationType] = operation
                            }
                        };
                    }
                }

                apiInfo.AddDocument(new OpenApiDocument
                {
                    Info = InfoBuilder.CreateValue(controllerGroup.Key, schemaRegistry),
                    Components = new OpenApiComponents
                    {
                        Schemas = schemaRegistry
                    },
                    Paths = paths
                });
            }

            return apiInfo;
        }

        public static void SetControllerReader<TReader>() where TReader : ApiReader<Type, ControllerInfo>, new()
        {
            ControllerReader = new TReader();
        }

        public static void SetEndpointReader<TReader>() where TReader : ApiReader<MethodInfo, EndpointInfo>, new()
        {
            EndpointReader = new TReader();
        }

        public static void SetInfoBuilder<TBuilder>() where TBuilder : ApiBuilder<ApiVersion, OpenApiInfo>, new()
        {
            InfoBuilder = new InfoBuilder();
        }

        public static void SetOperationBuilder<TBuilder>() where TBuilder : ApiBuilder<EndpointInfo, OpenApiOperation>, new()
        {
            OperationBuilder = new TBuilder();
        }

        public static void SetRequestBuilder<TBuilder>() where TBuilder : ApiBuilder<EndpointInfo, RequestInfo>, new()
        {
            RequestBuilder = new TBuilder();
        }

        public static void SetResponseBuilder<TBuilder>() where TBuilder : ApiBuilder<EndpointInfo, OpenApiResponses>, new()
        {
            ResponseBuilder = new TBuilder();
        }

        public static void SetTagBuilder<TBuilder>() where TBuilder : ApiBuilder<ControllerInfo, IList<OpenApiTag>>, new()
        {
            TagBuilder = new TBuilder();
        }

        private static string GetPath(ControllerInfo controller, EndpointInfo endpoint, OpenApiOperation operation)
        {
            return $"/{controller.Name}/{endpoint.Name}{operation.Parameters.Where(request => request.In == ParameterLocation.Path).Aggregate(string.Empty, (current, parameter) => current + $"/{{{parameter.Name}}}")}";
        }
    }
}