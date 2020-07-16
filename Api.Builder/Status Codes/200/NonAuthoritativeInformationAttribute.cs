using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request was successful but the enclosed payload has been modified from that of the origin server's 200 OK response by a transforming proxy.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NonAuthoritativeInformationAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NonAuthoritativeInformationAttribute"/>.
        /// </summary>    
        public NonAuthoritativeInformationAttribute() : base(203)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NonAuthoritativeInformationAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NonAuthoritativeInformationAttribute(Type type) : base(type, 203)
        {
        }
    }
}