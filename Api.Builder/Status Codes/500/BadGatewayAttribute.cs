using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server, while acting as a gateway or proxy, received an invalid response from an inbound server it accessed while attempting to fulfill the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class BadGatewayAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="BadGatewayAttribute"/>.
        /// </summary>    
        public BadGatewayAttribute() : base(502)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="BadGatewayAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public BadGatewayAttribute(Type type) : base(type, 502)
        {
        }
    }
}