using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.OpenApi.Models;
using static System.Enum;

namespace Api.Builder
{
    public class OperationTypeReader : MetadataReader<OperationType>
    {
        public OperationTypeReader() : base("operation type")
        {
        }

        protected override bool TryGetFromAttribute(Attribute attribute, out OperationType value)
        {
            return TryGetFromAttribute<IActionHttpMethodProvider>(attribute, provider => Parse<OperationType>(provider.HttpMethods.First(), true), out value);
        }
    }
}