using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request could not be completed due to a conflict with the current state of the target resource. This code is used in situations where the user might be able to resolve the conflict and resubmit the request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ConflictAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConflictAttribute"/>.
        /// </summary>    
        public ConflictAttribute() : base(409)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ConflictAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ConflictAttribute(Type type) : base(type, 409)
        {
        }
    }
}