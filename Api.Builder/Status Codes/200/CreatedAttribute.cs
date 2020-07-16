using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The request has been fulfilled and has resulted in one or more new resources being created.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class CreatedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="CreatedAttribute"/>.
        /// </summary>    
        public CreatedAttribute() : base(201)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="CreatedAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public CreatedAttribute(Type type) : base(type, 201)
        {
        }
    }
}