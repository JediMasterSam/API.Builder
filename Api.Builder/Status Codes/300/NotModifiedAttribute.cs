using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// A conditional GET or HEAD request has been received and would have resulted in a 200 OK response if it were not for the fact that the condition evaluated to false.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NotModifiedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NotModifiedAttribute"/>.
        /// </summary>    
        public NotModifiedAttribute() : base(304)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NotModifiedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NotModifiedAttribute(Type type) : base(type, 304)
        {
        }
    }
}