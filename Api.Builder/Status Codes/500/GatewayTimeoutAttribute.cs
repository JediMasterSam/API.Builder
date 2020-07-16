using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server, while acting as a gateway or proxy, did not receive a timely response from an upstream server it needed to access in order to complete the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class GatewayTimeoutAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="GatewayTimeoutAttribute"/>.
        /// </summary>    
        public GatewayTimeoutAttribute() : base(504)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="GatewayTimeoutAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public GatewayTimeoutAttribute(Type type) : base(type, 504)
        {
        }
    }
}