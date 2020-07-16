using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    /// <summary>
    /// The server refuses to perform the request using the current protocol but might be willing to do so after the client upgrades to a different protocol.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class UpgradeRequiredAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="UpgradeRequiredAttribute"/>.
        /// </summary>    
        public UpgradeRequiredAttribute() : base(426)
        {
        }
        /// <summary>
        /// Creates a new instance of <see cref="UpgradeRequiredAttribute"/>.
        /// </summary>
        /// <param name="type">Response type.</param>
        public UpgradeRequiredAttribute(Type type) : base(type, 426)
        {
        }
    }
}