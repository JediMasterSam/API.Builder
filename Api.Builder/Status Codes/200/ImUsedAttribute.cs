using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server has fulfilled a GET request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ImUsedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ImUsedAttribute"/>.
        /// </summary>    
        public ImUsedAttribute() : base(226)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ImUsedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ImUsedAttribute(Type type) : base(type, 226)
        {
        }
    }
}