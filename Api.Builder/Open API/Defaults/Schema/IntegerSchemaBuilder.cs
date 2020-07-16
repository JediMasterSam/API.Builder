using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class IntegerSchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var schema = base.CreateSchema(schemaInfo, schemaRegistry);

            schema.Type = "integer";
            schema.Minimum = schemaInfo.Provider.Minimum()?.ToDecimal(CultureInfo);
            schema.Maximum = schemaInfo.Provider.Maximum()?.ToDecimal(CultureInfo);

            if (schemaInfo.Type == typeof(int))
            {
                schema.Format = "int32";
                schema.Default = schemaInfo.GetDefault<int>(value => new OpenApiInteger(value));
            }
            else
            {
                schema.Format = "int64";
                schema.Default = schemaInfo.GetDefault<long>(value => new OpenApiLong(value));
            }

            return schema;
        }

        protected override bool Validate<TProvider>(SchemaInfo<TProvider> schemaInfo)
        {
            return schemaInfo.Type == typeof(int) || schemaInfo.Type == typeof(long);
        }
    }
}