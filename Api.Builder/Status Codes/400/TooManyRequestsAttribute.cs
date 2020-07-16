using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The user has sent too many requests in a given amount of time ("rate limiting").
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class TooManyRequestsAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="TooManyRequestsAttribute"/>.
        /// </summary>    
        public TooManyRequestsAttribute() : base(429)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="TooManyRequestsAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public TooManyRequestsAttribute(Type type) : base(type, 429)
        {
        }
    }
}