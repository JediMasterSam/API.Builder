using System.Collections.Generic;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class NumberSchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var schema = base.CreateSchema(schemaInfo, schemaRegistry);

            schema.Type = "number";
            schema.Minimum = schemaInfo.Provider.Minimum()?.ToDecimal(CultureInfo);
            schema.Maximum = schemaInfo.Provider.Maximum()?.ToDecimal(CultureInfo);

            if (schemaInfo.Type == typeof(float))
            {
                schema.Format = "float";
                schema.Default = schemaInfo.GetDefault<float>(value => new OpenApiFloat(value));
            }
            else
            {
                schema.Format = "double";
                schema.Default = schemaInfo.GetDefault<double>(value => new OpenApiDouble(value));
            }

            return schema;
        }

        protected override bool Validate<TProvider>(SchemaInfo<TProvider> schemaInfo)
        {
            return schemaInfo.Type == typeof(float) || schemaInfo.Type == typeof(double);
        }
    }
}