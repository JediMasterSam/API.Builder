using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The origin server is refusing to service the request because the payload is in a format not supported by this method on the target resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class UnsupportedMediaTypeAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="UnsupportedMediaTypeAttribute"/>.
        /// </summary>    
        public UnsupportedMediaTypeAttribute() : base(415)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="UnsupportedMediaTypeAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public UnsupportedMediaTypeAttribute(Type type) : base(type, 415)
        {
        }
    }
}