using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NotFoundAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NotFoundAttribute"/>.
        /// </summary>    
        public NotFoundAttribute() : base(404)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NotFoundAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NotFoundAttribute(Type type) : base(type, 404)
        {
        }
    }
}