using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource is no longer available at the origin server and that this condition is likely to be permanent.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class GoneAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="GoneAttribute"/>.
        /// </summary>    
        public GoneAttribute() : base(410)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="GoneAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public GoneAttribute(Type type) : base(type, 410)
        {
        }
    }
}