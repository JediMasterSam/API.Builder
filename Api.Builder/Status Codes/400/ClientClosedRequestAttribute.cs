using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// A non-standard status code introduced by nginx for the case when a client closes the connection while nginx is processing the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ClientClosedRequestAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ClientClosedRequestAttribute"/>.
        /// </summary>    
        public ClientClosedRequestAttribute() : base(499)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ClientClosedRequestAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ClientClosedRequestAttribute(Type type) : base(type, 499)
        {
        }
    }
}