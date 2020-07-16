using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using static System.String;

namespace Api.Builder
{
    public class NameReader : MetadataReader<string>
    {
        public NameReader() : base("name")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out string value)
        {
            return TryGetFromAttribute<ControllerNameAttribute>(attribute, controllerName => controllerName.Name, out value) ||
                   TryGetFromAttribute<JsonPropertyAttribute>(attribute, jsonProperty => jsonProperty.PropertyName, out value) ||
                   TryGetFromAttribute<IModelNameProvider>(attribute, provider => provider.Name, out value) && !IsNullOrEmpty(value);
        }

        protected override bool TryGetFromMember(MemberInfo member, out string value)
        {
            value = member.Name;
            return true;
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out string value)
        {
            value = parameter.Name;
            return true;
        }
    }
}