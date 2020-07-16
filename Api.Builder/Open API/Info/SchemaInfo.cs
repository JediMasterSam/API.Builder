using System;
using System.Reflection;
using Microsoft.OpenApi.Any;

namespace Api.Builder
{
    public sealed class SchemaInfo<TProvider> where TProvider : ICustomAttributeProvider
    {
        internal SchemaInfo(TProvider provider)
        {
            var type = provider.Type();
            var underlyingType = provider.UnderlyingType();

            if (underlyingType != null)
            {
                type = underlyingType;
            }

            ElementType = provider.ElementType();
            Nullable = underlyingType != null;
            Provider = provider;
            Title = type.FullName?.Replace($"{type.Assembly.GetName().Name}.", string.Empty);
            Type = type;
        }

        public Type ElementType { get; }

        public bool Nullable { get; }

        public TProvider Provider { get; }

        public string Title { get; }

        public Type Type { get; }
        
        public IOpenApiAny GetDefault<TValue>(Func<TValue, IOpenApiAny> func)
        {
            return Provider.DefaultValue() is TValue value ? func(value) : !Nullable && Type.IsValueType ? func(default) : null;
        }
    }
}