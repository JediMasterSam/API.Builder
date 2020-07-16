using System.Collections.Generic;
using System.Reflection;

namespace Api.Builder
{
    public abstract class ApiReader<TProvider, TValue> where TProvider : ICustomAttributeProvider
    {
        public IEnumerable<TValue> GetValues(IEnumerable<TProvider> providers)
        {
            foreach (var provider in providers)
            {
                if (TryGetValue(provider, out var value))
                {
                    yield return value;
                }
            }
        }
        
        protected abstract bool TryGetValue(TProvider provider, out TValue value);
    }
}