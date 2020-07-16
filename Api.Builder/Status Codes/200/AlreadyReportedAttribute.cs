using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// Used inside a DAV: propstat response element to avoid enumerating the internal members of multiple bindings to the same collection repeatedly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class AlreadyReportedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="AlreadyReportedAttribute"/>.
        /// </summary>    
        public AlreadyReportedAttribute() : base(208)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="AlreadyReportedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public AlreadyReportedAttribute(Type type) : base(type, 208)
        {
        }
    }
}