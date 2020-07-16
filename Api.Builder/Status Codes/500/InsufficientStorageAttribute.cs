using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The method could not be performed on the resource because the server is unable to store the representation needed to successfully complete the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class InsufficientStorageAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="InsufficientStorageAttribute"/>.
        /// </summary>    
        public InsufficientStorageAttribute() : base(507)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="InsufficientStorageAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public InsufficientStorageAttribute(Type type) : base(type, 507)
        {
        }
    }
}