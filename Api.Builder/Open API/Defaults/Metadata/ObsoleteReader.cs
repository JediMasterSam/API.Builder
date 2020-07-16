using System;

namespace Api.Builder
{
    public class ObsoleteReader : MetadataReader<bool>
    {
        public ObsoleteReader() : base("obsolete status")
        {
        }
        protected override bool TryGetFromAttribute(Attribute attribute, out bool value)
        {
            return value = attribute is ObsoleteAttribute;
        }

       
    }
}