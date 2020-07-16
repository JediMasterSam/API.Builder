using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is unwilling to process the request because its header fields are too large. The request MAY be resubmitted after reducing the size of the request header fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class RequestHeaderFieldsTooLargeAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="RequestHeaderFieldsTooLargeAttribute"/>.
        /// </summary>    
        public RequestHeaderFieldsTooLargeAttribute() : base(431)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="RequestHeaderFieldsTooLargeAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public RequestHeaderFieldsTooLargeAttribute(Type type) : base(type, 431)
        {
        }
    }
}