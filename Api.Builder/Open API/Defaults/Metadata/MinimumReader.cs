using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Builder
{
    public class MinimumReader : MetadataReader<IConvertible>
    {
        public MinimumReader() : base("minimum")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out IConvertible value)
        {
            return TryGetFromAttribute<MinLengthAttribute>(attribute, minLength => minLength.Length, out value) || 
                   TryGetFromAttribute<RangeAttribute>(attribute, range => range.Minimum as IConvertible, out value);
        }
    }
}