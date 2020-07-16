using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource has been assigned a new permanent URI and any future references to this resource ought to use one of the enclosed URIs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MovedPermanentlyAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="MovedPermanentlyAttribute"/>.
        /// </summary>    
        public MovedPermanentlyAttribute() : base(301)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="MovedPermanentlyAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public MovedPermanentlyAttribute(Type type) : base(type, 301)
        {
        }
    }
}