using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The expectation given in the request's Expect header field could not be met by at least one of the inbound servers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ExpectationFailedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ExpectationFailedAttribute"/>.
        /// </summary>    
        public ExpectationFailedAttribute() : base(417)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ExpectationFailedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ExpectationFailedAttribute(Type type) : base(type, 417)
        {
        }
    }
}