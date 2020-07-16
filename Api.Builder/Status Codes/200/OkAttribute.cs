using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request has succeeded.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,  Inherited = false)]
    public class OkAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="OkAttribute"/>.
        /// </summary>    
        public OkAttribute() : base(200)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="OkAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public OkAttribute(Type type) : base(type, 200)
        {
        }
    }
}