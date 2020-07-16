using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server understands the content type of the request entity (hence a 415 Unsupported Media Type status code is inappropriate), and the syntax of the request entity is correct (thus a 400 Bad Request status code is inappropriate) but was unable to process the contained instructions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class UnprocessableEntityAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="UnprocessableEntityAttribute"/>.
        /// </summary>    
        public UnprocessableEntityAttribute() : base(422)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="UnprocessableEntityAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public UnprocessableEntityAttribute(Type type) : base(type, 422)
        {
        }
    }
}