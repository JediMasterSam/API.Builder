using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public abstract class ApiBuilder<TProvider, TValue>
    {
        protected const string MediaType = "application/json";
        
        protected internal abstract TValue CreateValue(TProvider provider, Dictionary<string, OpenApiSchema> schemaRegistry);
    }
}