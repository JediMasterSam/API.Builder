using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request has been accepted for processing, but the processing has not been completed. The request might or might not eventually be acted upon, as it might be disallowed when processing actually takes place.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class AcceptedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="AcceptedAttribute"/>.
        /// </summary>    
        public AcceptedAttribute() : base(202)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="AcceptedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public AcceptedAttribute(Type type) : base(type, 202)
        {
        }
    }
}