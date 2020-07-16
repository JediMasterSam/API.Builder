using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Nullable;

namespace Api.Builder
{
    public class RequiredReader : MetadataReader<bool>
    {
        public RequiredReader() : base("required status")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out bool value)
        {
            return TryGetFromAttribute<JsonPropertyAttribute>(attribute, jsonProperty => jsonProperty.Required == Required.Always, out value) || 
                   (value = attribute is JsonRequiredAttribute) || 
                   (value = attribute is RequiredAttribute) || 
                   (value = attribute is FromRouteAttribute);
        }

        protected override bool TryGetFromField(FieldInfo field, out bool value)
        {
            value = IsValueType(field.FieldType) && !field.IsInitOnly && field.IsPublic;
            return true;
        }

        protected override bool TryGetFromProperty(PropertyInfo property, out bool value)
        {
            value = IsValueType(property.PropertyType) && property.GetSetMethod() != null;
            return true;
        }

        private static bool IsValueType(Type type)
        {
            return type.IsValueType && GetUnderlyingType(type) == null;
        }
    }
}