using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Api.Builder
{
    public class ElementTypeReader : MetadataReader<Type>
    {
        public ElementTypeReader() : base("element type")
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
            value = (IsEnumerable(type) ? type : type.GetInterfaces().FirstOrDefault(IsEnumerable))?.GetGenericArguments().FirstOrDefault();
            return true;
        }

        private static bool IsEnumerable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}