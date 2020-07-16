using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Builder
{
    public class MaximumReader : MetadataReader<IConvertible>
    {
        public MaximumReader() : base("maximum")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out IConvertible value)
        {
            return TryGetFromAttribute<MaxLengthAttribute>(attribute, maxLength => maxLength.Length, out value) || 
                   TryGetFromAttribute<RangeAttribute>(attribute, range => range.Maximum as IConvertible, out value);
        }
    }
}