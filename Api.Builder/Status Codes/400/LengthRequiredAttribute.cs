using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server refuses to accept the request without a defined Content-Length.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LengthRequiredAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="LengthRequiredAttribute"/>.
        /// </summary>    
        public LengthRequiredAttribute() : base(411)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="LengthRequiredAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public LengthRequiredAttribute(Type type) : base(type, 411)
        {
        }
    }
}