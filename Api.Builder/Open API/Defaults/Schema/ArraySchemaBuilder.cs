using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class ArraySchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var schema = base.CreateSchema(schemaInfo, schemaRegistry);
            
            schema.Type = "array";
            schema.Items = schemaInfo.ElementType.CreateSchema(schemaRegistry);
            schema.MinLength = schemaInfo.Provider.Minimum()?.ToInt32(CultureInfo);
            schema.MaxLength = schemaInfo.Provider.Maximum()?.ToInt32(CultureInfo);

            return schema;
        }

        protected override bool Validate<TProvider>(SchemaInfo<TProvider> schemaInfo)
        {
            return schemaInfo.Type != typeof(string) && schemaInfo.ElementType != null;
        }
    }
}