using System;
using System.ComponentModel;
using System.Reflection;
using static System.Activator;
using static System.Type;

namespace Api.Builder
{
    public class DefaultValueReader : MetadataReader<object>
    {
        public DefaultValueReader() : base("default value")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out object value)
        {
            return TryGetFromAttribute<DefaultValueAttribute>(attribute, defaultValue => defaultValue.Value, out value);
        }

        protected override bool TryGetFromField(FieldInfo field, out object value)
        {
            var instance = DefaultConstructor(field.ReflectedType);

            if (instance == null)
            {
                return TryGetFromType(field.FieldType, out value);
            }

            value = field.GetValue(instance);
            return true;
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out object value)
        {
            value = parameter.DefaultValue;
            return true;
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out object value)
        {
            var instance = DefaultConstructor(property.ReflectedType);

            if (instance == null)
            {
                return TryGetFromType(property.PropertyType, out value);
            }

            value = property.GetValue(instance);
            return true;
        }

        protected override bool TryGetFromType(Type type, out object value)
        {
            value = type.IsValueType ? CreateInstance(type) : null;
            return true;
        }

        private static object DefaultConstructor(Type type)
        {
            return type.GetConstructor(EmptyTypes) != null ? CreateInstance(type) : null;
        }
    }
}