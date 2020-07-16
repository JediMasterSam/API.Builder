using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource has been assigned a new permanent URI and any future references to this resource ought to use one of the enclosed URIs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PermanentRedirectAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="PermanentRedirectAttribute"/>.
        /// </summary>    
        public PermanentRedirectAttribute() : base(308)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="PermanentRedirectAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public PermanentRedirectAttribute(Type type) : base(type, 308)
        {
        }
    }
}