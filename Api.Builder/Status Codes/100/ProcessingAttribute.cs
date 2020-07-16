using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// An interim response used to inform the client that the server has accepted the complete request, but has not yet completed it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ProcessingAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProcessingAttribute"/>.
        /// </summary>    
        public ProcessingAttribute() : base(102)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ProcessingAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ProcessingAttribute(Type type) : base(type, 102)
        {
        }
    }
}