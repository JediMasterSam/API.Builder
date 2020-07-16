using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is redirecting the user agent to a different resource, as indicated by a URI in the Location header field, which is intended to provide an indirect response to the original request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SeeOtherAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="SeeOtherAttribute"/>.
        /// </summary>    
        public SeeOtherAttribute() : base(303)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="SeeOtherAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public SeeOtherAttribute(Type type) : base(type, 303)
        {
        }
    }
}