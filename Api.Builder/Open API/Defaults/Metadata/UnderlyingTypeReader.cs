using System;
using System.Reflection;
using static System.Nullable;

namespace Api.Builder
{
    public class UnderlyingTypeReader : MetadataReader<Type>
    {
        public UnderlyingTypeReader() : base("underlying type")
        {
        }

        protected override bool TryGetFromField(FieldInfo field, out Type value)
        {
            return TryGetFromType(field.FieldType, out value);
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out Type value)
        {
            return TryGetFromType(parameter.ParameterType, out value);
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out Type value)
        {
            return TryGetFromType(property.PropertyType, out value);
        }

        protected override bool TryGetFromType(Type type, out Type value)
        {
            value = GetUnderlyingType(type);
            return true;
        }
    }
}