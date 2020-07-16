using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// Any attempt to brew coffee with a teapot should result in the error code "418 I'm a teapot". The resulting entity body MAY be short and stout.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ImATeapotAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ImATeapotAttribute"/>.
        /// </summary>    
        public ImATeapotAttribute() : base(418)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="ImATeapotAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public ImATeapotAttribute(Type type) : base(type, 418)
        {
        }
    }
}