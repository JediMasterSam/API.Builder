using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// This status code is not specified in any RFCs, but is used by some HTTP proxies to signal a network connect timeout behind the proxy to a client in front of the proxy.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NetworkConnectTimeoutErrorAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NetworkConnectTimeoutErrorAttribute"/>.
        /// </summary>    
        public NetworkConnectTimeoutErrorAttribute() : base(599)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NetworkConnectTimeoutErrorAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NetworkConnectTimeoutErrorAttribute(Type type) : base(type, 599)
        {
        }
    }
}