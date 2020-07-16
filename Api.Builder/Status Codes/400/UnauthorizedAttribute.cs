using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request has not been applied because it lacks valid authentication credentials for the target resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class UnauthorizedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="UnauthorizedAttribute"/>.
        /// </summary>    
        public UnauthorizedAttribute() : base(401)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="UnauthorizedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public UnauthorizedAttribute(Type type) : base(type, 401)
        {
        }
    }
}