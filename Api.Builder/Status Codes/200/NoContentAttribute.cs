using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NoContentAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NoContentAttribute"/>.
        /// </summary>    
        public NoContentAttribute() : base(204)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NoContentAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NoContentAttribute(Type type) : base(type, 204)
        {
        }
    }
}