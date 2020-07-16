using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server does not support the functionality required to fulfill the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NotImplementedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NotImplementedAttribute"/>.
        /// </summary>    
        public NotImplementedAttribute() : base(501)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NotImplementedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NotImplementedAttribute(Type type) : base(type, 501)
        {
        }
    }
}