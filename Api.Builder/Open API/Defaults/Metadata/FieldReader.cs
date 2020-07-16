using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Reflection.BindingFlags;

namespace Api.Builder
{
    public class FieldReader : MetadataReader<IEnumerable<FieldInfo>>
    {
        public FieldReader() : base("fields")
        {
        }

        protected override bool TryGetFromField(FieldInfo field, out IEnumerable<FieldInfo> value)
        {
            return TryGetFromType(field.FieldType, out value);
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out IEnumerable<FieldInfo> value)
        {
            return TryGetFromType(parameter.ParameterType, out value);
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out IEnumerable<FieldInfo> value)
        {
            return TryGetFromType(property.PropertyType, out value);
        }

        protected override bool TryGetFromType(Type type, out IEnumerable<FieldInfo> value)
        {
            value = type.GetFields(Public | Instance).Where(field => !field.IsInitOnly);
            return true;
        }
    }
}