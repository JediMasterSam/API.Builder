using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is denying access to the resource as a consequence of a legal demand.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class UnavailableForLegalReasonsAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="UnavailableForLegalReasonsAttribute"/>.
        /// </summary>    
        public UnavailableForLegalReasonsAttribute() : base(451)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="UnavailableForLegalReasonsAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public UnavailableForLegalReasonsAttribute(Type type) : base(type, 451)
        {
        }
    }
}