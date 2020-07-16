using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public sealed class RequestInfo
    {
        public RequestInfo()
        {
            Parameters = new List<OpenApiParameter>(); 
        }

        public List<OpenApiParameter> Parameters { get; }
        
        public OpenApiRequestBody RequestBody { get; set; }
    }
}