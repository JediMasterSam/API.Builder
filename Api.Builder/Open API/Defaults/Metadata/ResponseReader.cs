using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Api.Builder
{
    public class ResponseReader : MetadataReader<IEnumerable<ApiResponseType>>
    {
        public ResponseReader() : base("responses")
        {
        }

        protected override bool TryGetFromAttributes(IEnumerable<Attribute> attributes, out IEnumerable<ApiResponseType> value)
        {
            value = attributes.OfType<IApiResponseMetadataProvider>().Select(provider => new ApiResponseType {StatusCode = provider.StatusCode, Type = provider.Type});
            return true;
        }
    }
}