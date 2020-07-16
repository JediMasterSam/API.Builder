using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource resides temporarily under a different URI and the user agent MUST NOT change the request method if it performs an automatic redirection to that URI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class TemporaryRedirectAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="TemporaryRedirectAttribute"/>.
        /// </summary>    
        public TemporaryRedirectAttribute() : base(307)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="TemporaryRedirectAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public TemporaryRedirectAttribute(Type type) : base(type, 307)
        {
        }
    }
}