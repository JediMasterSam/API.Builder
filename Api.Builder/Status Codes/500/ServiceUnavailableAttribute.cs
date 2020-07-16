using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ServiceUnavailableAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ServiceUnavailableAttribute"/>.
        /// </summary>    
        public ServiceUnavailableAttribute() : base(503)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ServiceUnavailableAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ServiceUnavailableAttribute(Type type) : base(type, 503)
        {
        }
    }
}