using System;
using System.Reflection;

namespace Api.Builder
{
    public class TypeReader : MetadataReader<Type>
    {
        public TypeReader() : base("type")
        {
        }

        protected override bool TryGetFromField(FieldInfo field, out Type value)
        {
            value = field.FieldType;
            return true;
        }

        protected override bool TryGetFromMethod(MethodInfo method, out Type value)
        {
            value = method.ReturnType;
            return true;
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out Type value)
        {
            value = parameter.ParameterType;
            return true;
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out Type value)
        {
            value = property.PropertyType;
            return true;
        }

        protected override bool TryGetFromType(Type type, out Type value)
        {
            value = type;
            return true;
        }
    }
}