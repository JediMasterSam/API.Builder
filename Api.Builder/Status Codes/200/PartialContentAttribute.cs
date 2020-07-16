using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server is successfully fulfilling a range request for the target resource by transferring one or more parts of the selected representation that correspond to the satisfiable ranges found in the request's Range header field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PartialContentAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="PartialContentAttribute"/>.
        /// </summary>    
        public PartialContentAttribute() : base(206)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="PartialContentAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public PartialContentAttribute(Type type) : base(type, 206)
        {
        }
    }
}