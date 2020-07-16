using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    public class ApiVersionReader : MetadataReader<ApiVersion>
    {
        public ApiVersionReader() : base("API version")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out ApiVersion value)
        {
            return TryGetFromAttribute<ApiVersionAttribute>(attribute, apiVersion => apiVersion.Versions.First(), out value);
        }

        protected override bool TryGetFromMethod(MethodInfo method, out ApiVersion value)
        {
            return TryGetFromAttributes(method.ReflectedType, out value);
        }
    }
}