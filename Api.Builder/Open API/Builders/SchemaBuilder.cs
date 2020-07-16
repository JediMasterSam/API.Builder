using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public abstract class SchemaBuilder
    {
        protected static readonly CultureInfo CultureInfo = CultureInfo.CurrentCulture;

        internal bool TryCreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry, out OpenApiSchema schema) where TProvider : ICustomAttributeProvider
        {
            if (Validate(schemaInfo))
            {
                schema = CreateSchema(schemaInfo, schemaRegistry);
                return true;
            }

            schema = null;
            return false;
        }

        protected internal virtual OpenApiSchema CreateSchema<TProvider>(SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry) where TProvider : ICustomAttributeProvider
        {
            return new OpenApiSchema
            {
                Description = schemaInfo.Provider.Description(),
                Deprecated = schemaInfo.Provider.Obsolete(),
                Nullable = schemaInfo.Nullable
            };
        }

        protected virtual bool Validate<TProvider>(SchemaInfo<TProvider> schemaInfo) where TProvider : ICustomAttributeProvider
        {
            return true;
        }
    }
}