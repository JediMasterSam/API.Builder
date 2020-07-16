using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The initial part of a request has been received and has not yet been rejected by the server. The server intends to send a final response after the request has been fully received and acted upon.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ContinueAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ContinueAttribute"/>.
        /// </summary>    
        public ContinueAttribute() : base(100)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ContinueAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ContinueAttribute(Type type) : base(type, 100)
        {
        }
    }
}