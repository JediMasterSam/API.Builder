using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The source or destination resource of a method is locked.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LockedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="LockedAttribute"/>.
        /// </summary>    
        public LockedAttribute() : base(423)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="LockedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public LockedAttribute(Type type) : base(type, 423)
        {
        }
    }
}