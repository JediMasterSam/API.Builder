using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server has fulfilled the request and desires that the user agent reset the "document view", which caused the request to be sent, to its original state as received from the origin server.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ResetContentAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ResetContentAttribute"/>.
        /// </summary>    
        public ResetContentAttribute() : base(205)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ResetContentAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ResetContentAttribute(Type type) : base(type, 205)
        {
        }
    }
}