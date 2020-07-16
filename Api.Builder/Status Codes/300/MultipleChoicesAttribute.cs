using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource has more than one representation, each with its own more specific identifier, and information about the alternatives is being provided so that the user (or user agent) can select a preferred representation by redirecting its request to one or more of those identifiers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MultipleChoicesAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="MultipleChoicesAttribute"/>.
        /// </summary>    
        public MultipleChoicesAttribute() : base(300)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="MultipleChoicesAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public MultipleChoicesAttribute(Type type) : base(type, 300)
        {
        }
    }
}