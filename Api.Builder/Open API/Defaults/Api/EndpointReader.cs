using System.Reflection;

namespace Api.Builder
{
    public class EndpointReader : ApiReader<MethodInfo, EndpointInfo>
    {
        protected override bool TryGetValue(MethodInfo method, out EndpointInfo endpoint)
        {
            if (method.Obsolete())
            {
                endpoint = null;
                return false;
            }

            endpoint = new EndpointInfo(method);

            return !endpoint.Responses.IsEmpty;
        }
    }
}