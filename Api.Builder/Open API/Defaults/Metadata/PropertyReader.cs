using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Reflection.BindingFlags;

namespace Api.Builder
{
    public class PropertyReader : MetadataReader<IEnumerable<PropertyInfo>>
    {
        public PropertyReader() : base("properties")
        {
        }

        protected override bool TryGetFromField(FieldInfo field, out IEnumerable<PropertyInfo> value)
        {
            return TryGetFromType(field.FieldType, out value);
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out IEnumerable<PropertyInfo> value)
        {
            return TryGetFromType(parameter.ParameterType, out value);
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out IEnumerable<PropertyInfo> value)
        {
            return TryGetFromType(property.PropertyType, out value);
        }

        protected override bool TryGetFromType(Type type, out IEnumerable<PropertyInfo> value)
        {
            value = type.GetProperties(Instance | Public).Where(property => property.GetGetMethod() != null && property.GetSetMethod() != null);
            return true;
        }
    }
}