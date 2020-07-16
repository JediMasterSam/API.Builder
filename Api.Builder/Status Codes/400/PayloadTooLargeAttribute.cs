using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is refusing to process a request because the request payload is larger than the server is willing or able to process.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PayloadTooLargeAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="PayloadTooLargeAttribute"/>.
        /// </summary>    
        public PayloadTooLargeAttribute() : base(413)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="PayloadTooLargeAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public PayloadTooLargeAttribute(Type type) : base(type, 413)
        {
        }
    }
}