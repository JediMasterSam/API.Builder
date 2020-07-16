using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using static System.Reflection.BindingFlags;

namespace Api.Builder
{
    public class MethodReader : MetadataReader<IEnumerable<MethodInfo>>
    {
        public MethodReader() : base("methods")
        {
            IgnoredMethods = typeof(object).GetMethods(Public | Instance).ToImmutableArray();
        }
        
        private ImmutableArray<MethodInfo> IgnoredMethods { get; }

        protected override bool TryGetFromField(FieldInfo field, out IEnumerable<MethodInfo> value)
        {
            return TryGetFromType(field.FieldType, out value);
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out IEnumerable<MethodInfo> value)
        {
            return TryGetFromType(parameter.ParameterType, out value);
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out IEnumerable<MethodInfo> value)
        {
            return TryGetFromType(property.PropertyType, out value);
        }

        protected override bool TryGetFromType(Type type, out IEnumerable<MethodInfo> value)
        {
            value = type.GetMethods(Public | Instance).Where(method => !IgnoredMethods.Contains(method));
            return true;
        }
    }
}