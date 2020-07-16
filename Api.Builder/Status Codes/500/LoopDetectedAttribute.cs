using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server terminated an operation because it encountered an infinite loop while processing a request with "Depth: infinity". This status indicates that the entire operation failed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LoopDetectedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="LoopDetectedAttribute"/>.
        /// </summary>    
        public LoopDetectedAttribute() : base(508)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="LoopDetectedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public LoopDetectedAttribute(Type type) : base(type, 508)
        {
        }
    }
}