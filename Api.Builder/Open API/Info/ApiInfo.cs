using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public sealed class ApiInfo
    {
        public ApiInfo()
        {
            Documents = new List<OpenApiDocument>();
            Routes = new List<RouteInfo>();
        }

        private List<OpenApiDocument> Documents { get; }

        private List<RouteInfo> Routes { get; }

        public void AddDocument(OpenApiDocument document)
        {
            Documents.Add(document);
        }

        public RouteInfo AddRoute(ControllerInfo controller, EndpointInfo endpoint, OpenApiOperation operation)
        {
            var route = new RouteInfo(controller, endpoint, operation);
            
            Routes.Add(route);
            
            return route;
        }

        public IEnumerable<OpenApiDocument> GetDocuments()
        {
            return Documents;
        }

        public IEnumerable<RouteInfo> GetRoutes()
        {
            return Routes;
        }
    }
}