using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Api.Builder
{
    public abstract class MetadataReader<TValue>
    {
        protected MetadataReader(string name)
        {
            Name = name;
        }

        private string Name { get; }

        private delegate bool TryGet<in TElement>(TElement element, out TValue value);

        internal TValue GetFromProvider<TProvider>(TProvider provider) where TProvider : ICustomAttributeProvider
        {
            try
            {
                return provider switch
                {
                    FieldInfo field => GetFromField(field),
                    MethodInfo method => GetFromMethod(method),
                    ParameterInfo parameter => GetFromParameter(parameter),
                    PropertyInfo property => GetFromProperty(property),
                    Type type => GetFromType(type),
                    _ => throw new ArgumentOutOfRangeException(nameof(provider))
                };
            }
            catch (Exception exception)
            {
                throw new AggregateException(new Exception($"Cannot get the {Name} from {provider}."), exception);
            }
        }

        protected static bool TryGetFromAttribute<TProvider>(Attribute attribute, Func<TProvider, TValue> getValue, out TValue value)
        {
            if (attribute is TProvider provider)
            {
                value = getValue(provider);
                return true;
            }

            value = default;
            return false;
        }
        
        protected bool TryGetFromAttributes(ICustomAttributeProvider provider, out TValue value)
        {
            return TryGetFromAttributes(provider.GetCustomAttributes(false).OfType<Attribute>(), out value);
        }

        protected virtual bool TryGetFromAttribute(Attribute attribute, out TValue value)
        {
            value = default;
            return false;
        }

        protected virtual bool TryGetFromAttributes(IEnumerable<Attribute> attributes, out TValue value)
        {
            foreach (var attribute in attributes)
            {
                if (TryGetFromAttribute(attribute, out value)) return true;
            }

            value = default;
            return false;
        }

        protected virtual bool TryGetFromField(FieldInfo field, out TValue value)
        {
            value = default;
            return false;
        }

        protected virtual bool TryGetFromMember(MemberInfo member, out TValue value)
        {
            value = default;
            return false;
        }

        protected virtual bool TryGetFromMethod(MethodInfo method, out TValue value)
        {
            value = default;
            return false;
        }

        protected virtual bool TryGetFromParameter(ParameterInfo parameter, out TValue value)
        {
            value = default;
            return false;
        }

        protected virtual bool TryGetFromProperty(PropertyInfo property, out TValue value)
        {
            value = default;
            return false;
        }

        protected virtual bool TryGetFromType(Type type, out TValue value)
        {
            value = default;
            return false;
        }

        private TValue GetFromField(FieldInfo field)
        {
            return GetFromMember(field, TryGetFromField);
        }

        private TValue GetFromMember<TMember>(TMember member, TryGet<TMember> tryGet) where TMember : MemberInfo
        {
            return TryGetFromAttributes(member, out var value) || tryGet(member, out value) || TryGetFromMember(member, out value) ? value : default;
        }

        private TValue GetFromMethod(MethodInfo method)
        {
            return GetFromMember(method, TryGetFromMethod);
        }

        private TValue GetFromParameter(ParameterInfo parameter)
        {
            return TryGetFromAttributes(parameter, out var value) || TryGetFromParameter(parameter, out value) ? value : default;
        }

        private TValue GetFromProperty(PropertyInfo property)
        {
            return GetFromMember(property, TryGetFromProperty);
        }

        private TValue GetFromType(Type type)
        {
            return GetFromMember(type, TryGetFromType);
        }
    }
}