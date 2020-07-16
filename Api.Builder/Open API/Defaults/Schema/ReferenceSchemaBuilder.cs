using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class ReferenceSchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            return new OpenApiSchema
            {
                Description = schemaInfo.Type.Description(),
                Deprecated = schemaInfo.Type.Obsolete(),
                Reference = new OpenApiReference
                {
                    Id = schemaInfo.Title,
                    Type = ReferenceType.Schema
                }
            };
        }
    }
}