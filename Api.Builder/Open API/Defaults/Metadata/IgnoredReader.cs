using System;
using Newtonsoft.Json;

namespace Api.Builder
{
    public class IgnoredReader : MetadataReader<bool>
    {
        public IgnoredReader() : base("ignored status")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out bool value)
        {
            return value = attribute is JsonIgnoreAttribute;
        }
    }
}