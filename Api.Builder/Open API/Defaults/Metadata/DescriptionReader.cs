using System;
using System.ComponentModel;
using System.Reflection;
using Namotion.Reflection;

namespace Api.Builder
{
    public class DescriptionReader : MetadataReader<string>
    {
        public DescriptionReader() : base("description")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out string value)
        {
            return TryGetFromAttribute<DescriptionAttribute>(attribute, description => description.Description, out value);
        }

        protected override bool TryGetFromMember(MemberInfo member, out string value)
        {
            value = member.GetXmlDocsSummary();
            return true;
        }

        protected override bool TryGetFromParameter(ParameterInfo parameter, out string value)
        {
            value = parameter.GetXmlDocs();
            return true;
        }
    }
}