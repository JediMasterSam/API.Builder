using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server does not support, or refuses to support, the major version of HTTP that was used in the request message.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class HttpVersionNotSupportedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="HttpVersionNotSupportedAttribute"/>.
        /// </summary>    
        public HttpVersionNotSupportedAttribute() : base(505)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="HttpVersionNotSupportedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public HttpVersionNotSupportedAttribute(Type type) : base(type, 505)
        {
        }
    }
}