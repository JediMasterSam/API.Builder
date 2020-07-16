using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    public class DeprecatedReader : MetadataReader<bool>
    {
        public DeprecatedReader() : base("deprecated status")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out bool value)
        {
            return TryGetFromAttribute<ApiVersionAttribute>(attribute, apiVersion => apiVersion.Deprecated, out value);
        }

        protected override bool TryGetFromMethod(MethodInfo method, out bool value)
        {
            return TryGetFromType(method.ReflectedType, out value) || TryGetFromType(method.DeclaringType, out value);
        }
    }
}