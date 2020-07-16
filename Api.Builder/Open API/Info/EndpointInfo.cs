using System.Collections.Immutable;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public sealed class EndpointInfo
    {
        internal EndpointInfo(MethodInfo method)
        {
            Method = method;
            Name = method.Name();
            OperationType = method.OperationType();
            Responses = method.Responses().ToImmutableArray();
        }

        public MethodInfo Method { get; }

        public string Name { get; }

        public OperationType OperationType { get; }

        public ImmutableArray<ApiResponseType> Responses { get; }
    }
}