using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server encountered an unexpected condition that prevented it from fulfilling the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class InternalServerErrorAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="InternalServerErrorAttribute"/>.
        /// </summary>    
        public InternalServerErrorAttribute() : base(500)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="InternalServerErrorAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public InternalServerErrorAttribute(Type type) : base(type, 500)
        {
        }
    }
}