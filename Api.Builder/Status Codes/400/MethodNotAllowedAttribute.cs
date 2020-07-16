using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The method received in the request-line is known by the origin server but not supported by the target resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MethodNotAllowedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="MethodNotAllowedAttribute"/>.
        /// </summary>    
        public MethodNotAllowedAttribute() : base(405)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="MethodNotAllowedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public MethodNotAllowedAttribute(Type type) : base(type, 405)
        {
        }
    }
}