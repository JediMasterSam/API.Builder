using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// A Multi-Status response conveys information about multiple resources in situations where multiple status codes might be appropriate.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MultiStatusAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="MultiStatusAttribute"/>.
        /// </summary>    
        public MultiStatusAttribute() : base(207)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="MultiStatusAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public MultiStatusAttribute(Type type) : base(type, 207)
        {
        }
    }
}