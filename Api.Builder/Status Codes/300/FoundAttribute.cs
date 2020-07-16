using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The target resource resides temporarily under a different URI. Since the redirection might be altered on occasion, the client ought to continue to use the effective request URI for future requests.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class FoundAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="FoundAttribute"/>.
        /// </summary>    
        public FoundAttribute() : base(302)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="FoundAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public FoundAttribute(Type type) : base(type, 302)
        {
        }
    }
}