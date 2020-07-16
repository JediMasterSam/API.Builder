using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, or deceptive request routing).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class BadRequestAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="BadRequestAttribute"/>.
        /// </summary>    
        public BadRequestAttribute() : base(400)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="BadRequestAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public BadRequestAttribute(Type type) : base(type, 400)
        {
        }
    }
}