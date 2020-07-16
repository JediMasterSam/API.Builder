using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The client needs to authenticate to gain network access.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NetworkAuthenticationRequiredAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NetworkAuthenticationRequiredAttribute"/>.
        /// </summary>    
        public NetworkAuthenticationRequiredAttribute() : base(511)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NetworkAuthenticationRequiredAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NetworkAuthenticationRequiredAttribute(Type type) : base(type, 511)
        {
        }
    }
}