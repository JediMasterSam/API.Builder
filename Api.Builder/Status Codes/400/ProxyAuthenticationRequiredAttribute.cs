using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server did not receive a complete request message within the time that it was prepared to wait.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ProxyAuthenticationRequiredAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProxyAuthenticationRequiredAttribute"/>.
        /// </summary>    
        public ProxyAuthenticationRequiredAttribute() : base(407)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ProxyAuthenticationRequiredAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ProxyAuthenticationRequiredAttribute(Type type) : base(type, 407)
        {
        }
    }
}