using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// None of the ranges in the request's Range header field overlap the current extent of the selected resource or that the set of ranges requested has been rejected due to invalid ranges or an excessive request of small or overlapping ranges.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class RequestedRangeNotSatisfiableAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="RequestedRangeNotSatisfiableAttribute"/>.
        /// </summary>    
        public RequestedRangeNotSatisfiableAttribute() : base(416)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="RequestedRangeNotSatisfiableAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public RequestedRangeNotSatisfiableAttribute(Type type) : base(type, 416)
        {
        }
    }
}