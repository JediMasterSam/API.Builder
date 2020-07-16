using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request was directed at a server that is not able to produce a response. This can be sent by a server that is not configured to produce responses for the combination of scheme and authority that are included in the request URI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MisdirectedRequestAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="MisdirectedRequestAttribute"/>.
        /// </summary>    
        public MisdirectedRequestAttribute() : base(421)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="MisdirectedRequestAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public MisdirectedRequestAttribute(Type type) : base(type, 421)
        {
        }
    }
}