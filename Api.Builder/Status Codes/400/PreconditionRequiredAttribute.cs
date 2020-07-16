using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The origin server requires the request to be conditional.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PreconditionRequiredAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="PreconditionRequiredAttribute"/>.
        /// </summary>    
        public PreconditionRequiredAttribute() : base(428)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="PreconditionRequiredAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public PreconditionRequiredAttribute(Type type) : base(type, 428)
        {
        }
    }
}