using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Builder
{
    public class BindingSourceReader : MetadataReader<BindingSource>
    {
        public BindingSourceReader() : base("binding source")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out BindingSource value)
        {
            return TryGetFromAttribute<IBindingSourceMetadata>(attribute, metadata => metadata.BindingSource, out value);
        }
    }
}