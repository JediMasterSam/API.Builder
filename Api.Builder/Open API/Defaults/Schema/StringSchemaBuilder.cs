using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using static System.Enum;

namespace Api.Builder
{
    public class StringSchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var schema = base.CreateSchema(schemaInfo, schemaRegistry);
           
            schema.Type = "string";

            if (schemaInfo.Type == typeof(string))
            {
                schema.Default = schemaInfo.GetDefault<string>(value => new OpenApiString(value));
                schema.MinLength = schemaInfo.Provider.Minimum()?.ToInt32(CultureInfo);
                schema.MaxLength = schemaInfo.Provider.Maximum()?.ToInt32(CultureInfo);
            }
            else if (schemaInfo.Type == typeof(DateTime))
            {
                schema.Format = "date";
                schema.Default = schemaInfo.GetDefault<DateTime>(value => new OpenApiDate(value));
            }
            else if (schemaInfo.Type == typeof(DateTimeOffset))
            {
                schema.Format = "date-time";
                schema.Default = schemaInfo.GetDefault<DateTimeOffset>(value => new OpenApiDateTime(value));
            }
            else
            {
                var names = GetNames(schemaInfo.Type).Select(name => (IOpenApiAny) new OpenApiString(name)).ToArray();

                schema.Enum = names;
                schema.Default = names.FirstOrDefault();
                schema.Title = schemaInfo.Title;
                schema.Description = schemaInfo.Type.Description();

                schemaRegistry[schemaInfo.Title] = schema;

                return schemaInfo.CreateReference(schemaRegistry);
            }

            return schema;
        }

        protected override bool Validate<TProvider>(SchemaInfo<TProvider> schemaInfo)
        {
            return schemaInfo.Type == typeof(string) || schemaInfo.Type == typeof(DateTime) || schemaInfo.Type == typeof(DateTimeOffset) || schemaInfo.Type.IsEnum;
        }
    }
}