using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class ObjectSchemaBuilder : SchemaBuilder
    {
        protected internal override OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            var schema = base.CreateSchema(schemaInfo, schemaRegistry);

            schema.Type = "object";
            schema.Title = schemaInfo.Title;
            schema.Description = schemaInfo.Type.Description();

            var required = new HashSet<string>();
            var properties = new Dictionary<string, OpenApiSchema>();

            foreach (var property in schemaInfo.Provider.Properties())
            {
                if (property.Ignored()) continue;

                var name = property.Name();

                if (property.Required())
                {
                    required.Add(name);
                }

                properties[name] = property.CreateSchema(schemaRegistry);
            }
            
            schema.Required = required;
            schema.Properties = properties;

            return schema;
        }
    }
}