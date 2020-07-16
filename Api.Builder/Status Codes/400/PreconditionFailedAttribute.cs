using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// One or more conditions given in the request header fields evaluated to false when tested on the server.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PreconditionFailedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="PreconditionFailedAttribute"/>.
        /// </summary>    
        public PreconditionFailedAttribute() : base(412)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="PreconditionFailedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public PreconditionFailedAttribute(Type type) : base(type, 412)
        {
        }
    }
}