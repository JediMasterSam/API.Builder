using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server has an internal configuration error: the chosen variant resource is configured to engage in transparent content negotiation itself, and is therefore not a proper end point in the negotiation process.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class VariantAlsoNegotiatesAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="VariantAlsoNegotiatesAttribute"/>.
        /// </summary>    
        public VariantAlsoNegotiatesAttribute() : base(506)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="VariantAlsoNegotiatesAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public VariantAlsoNegotiatesAttribute(Type type) : base(type, 506)
        {
        }
    }
}