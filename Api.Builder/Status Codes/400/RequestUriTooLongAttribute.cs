using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is refusing to service the request because the request-target is longer than the server is willing to interpret.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class RequestUriTooLongAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="RequestUriTooLongAttribute"/>.
        /// </summary>    
        public RequestUriTooLongAttribute() : base(414)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="RequestUriTooLongAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public RequestUriTooLongAttribute(Type type) : base(type, 414)
        {
        }
    }
}