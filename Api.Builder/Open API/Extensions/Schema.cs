using System.Collections.Generic;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public static class Schema
    {
        private static SchemaBuilder ArraySchemaBuilder { get; set; } = new ArraySchemaBuilder();

        private static SchemaBuilder BooleanSchemaBuilder { get; set; } = new BooleanSchemaBuilder();

        private static SchemaBuilder IntegerSchemaBuilder { get; set; } = new IntegerSchemaBuilder();

        private static SchemaBuilder NumberSchemaBuilder { get; set; } = new NumberSchemaBuilder();

        private static SchemaBuilder ObjectSchemaBuilder { get; set; } = new ObjectSchemaBuilder();

        private static SchemaBuilder ReferenceSchemaBuilder { get; set; } = new ReferenceSchemaBuilder();

        private static SchemaBuilder StringSchemaBuilder { get; set; } = new StringSchemaBuilder();

        public static OpenApiSchema CreateSchema<TProvider>(this TProvider provider, Dictionary<string, OpenApiSchema> schemaRegistry) where TProvider : ICustomAttributeProvider
        {
            var schemaInfo = new SchemaInfo<TProvider>(provider);

            if (schemaRegistry.TryGetValue(schemaInfo.Title, out var schema))
            {
                return ReferenceSchemaBuilder.CreateSchema(schemaInfo, schemaRegistry);
            }

            if (BooleanSchemaBuilder.TryCreateSchema(schemaInfo, schemaRegistry, out schema) ||
                IntegerSchemaBuilder.TryCreateSchema(schemaInfo, schemaRegistry, out schema) ||
                NumberSchemaBuilder.TryCreateSchema(schemaInfo, schemaRegistry, out schema) ||
                StringSchemaBuilder.TryCreateSchema(schemaInfo, schemaRegistry, out schema) ||
                ArraySchemaBuilder.TryCreateSchema(schemaInfo, schemaRegistry, out schema)) return schema;

            schemaRegistry[schemaInfo.Title] = ObjectSchemaBuilder.CreateSchema(schemaInfo, schemaRegistry);

            return ReferenceSchemaBuilder.CreateSchema(schemaInfo, schemaRegistry);
        }

        public static OpenApiSchema CreateReference<TProvider>(this SchemaInfo<TProvider> schemaInfo, Dictionary<string, OpenApiSchema> schemaRegistry) where TProvider : ICustomAttributeProvider
        {
            return ReferenceSchemaBuilder.CreateSchema(schemaInfo, schemaRegistry);
        }

        public static void SetArraySchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            ArraySchemaBuilder = new TSchemaBuilder();
        }

        public static void SetBooleanSchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            BooleanSchemaBuilder = new TSchemaBuilder();
        }

        public static void SetIntegerSchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            IntegerSchemaBuilder = new TSchemaBuilder();
        }

        public static void SeNumberSchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            NumberSchemaBuilder = new TSchemaBuilder();
        }

        public static void SetObjectSchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            ObjectSchemaBuilder = new TSchemaBuilder();
        }

        public static void SeReferenceSchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            ReferenceSchemaBuilder = new TSchemaBuilder();
        }

        public static void SetStringSchemaBuilder<TSchemaBuilder>() where TSchemaBuilder : SchemaBuilder, new()
        {
            StringSchemaBuilder = new TSchemaBuilder();
        }
    }
}