using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The method could not be performed on the resource because the requested action depended on another action and that action failed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class FailedDependencyAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="FailedDependencyAttribute"/>.
        /// </summary>    
        public FailedDependencyAttribute() : base(424)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="FailedDependencyAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public FailedDependencyAttribute(Type type) : base(type, 424)
        {
        }
    }
}