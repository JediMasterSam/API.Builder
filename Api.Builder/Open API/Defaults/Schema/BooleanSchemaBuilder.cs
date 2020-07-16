using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class BooleanSchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var schema = base.CreateSchema(schemaInfo, schemaRegistry);

            schema.Type = "boolean";
            schema.Default = schemaInfo.GetDefault<bool>(value => new OpenApiBoolean(value));

            return schema;
        }

        protected override bool Validate<TProvider>(SchemaInfo<TProvider> schemaInfo)
        {
            return schemaInfo.Type == typeof(bool);
        }
    }
}