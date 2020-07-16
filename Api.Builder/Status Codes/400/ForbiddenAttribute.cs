using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server understood the request but refuses to authorize it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ForbiddenAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ForbiddenAttribute"/>.
        /// </summary>    
        public ForbiddenAttribute() : base(403)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ForbiddenAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ForbiddenAttribute(Type type) : base(type, 403)
        {
        }
    }
}