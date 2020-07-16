using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// A non-standard status code used to instruct nginx to close the connection without sending a response to the client, most commonly used to deny malicious or malformed requests.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ConnectionClosedWithoutResponseAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConnectionClosedWithoutResponseAttribute"/>.
        /// </summary>    
        public ConnectionClosedWithoutResponseAttribute() : base(444)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ConnectionClosedWithoutResponseAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ConnectionClosedWithoutResponseAttribute(Type type) : base(type, 444)
        {
        }
    }
}