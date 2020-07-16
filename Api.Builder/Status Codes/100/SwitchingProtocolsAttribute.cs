using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server understands and is willing to comply with the client's request, via the Upgrade header field, for a change in the application protocol being used on this connection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SwitchingProtocolsAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="SwitchingProtocolsAttribute"/>.
        /// </summary>    
        public SwitchingProtocolsAttribute() : base(101)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="SwitchingProtocolsAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public SwitchingProtocolsAttribute(Type type) : base(type, 101)
        {
        }
    }
}