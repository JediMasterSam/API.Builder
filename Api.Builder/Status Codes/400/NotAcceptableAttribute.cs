using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource does not have a current representation that would be acceptable to the user agent, according to the proactive negotiation header fields received in the request, and the server is unwilling to supply a default representation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NotAcceptableAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NotAcceptableAttribute"/>.
        /// </summary>    
        public NotAcceptableAttribute() : base(406)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NotAcceptableAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NotAcceptableAttribute(Type type) : base(type, 406)
        {
        }
    }
}