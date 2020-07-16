using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The policy for accessing the resource has not been met in the request. The server should send back all the information necessary for the client to issue an extended request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NotExtendedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="NotExtendedAttribute"/>.
        /// </summary>    
        public NotExtendedAttribute() : base(510)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="NotExtendedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public NotExtendedAttribute(Type type) : base(type, 510)
        {
        }
    }
}