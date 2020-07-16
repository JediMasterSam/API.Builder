using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server did not receive a complete request message within the time that it was prepared to wait.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class RequestTimeoutAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="RequestTimeoutAttribute"/>.
        /// </summary>    
        public RequestTimeoutAttribute() : base(408)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="RequestTimeoutAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public RequestTimeoutAttribute(Type type) : base(type, 408)
        {
        }
    }
}