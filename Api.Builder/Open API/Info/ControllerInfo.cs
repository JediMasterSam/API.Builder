using System;
using Microsoft.AspNetCore.Mvc;
using static System.StringComparison;

namespace Api.Builder
{
    public sealed class ControllerInfo
    {
        internal ControllerInfo(Type type)
        {
            const string suffix = "controller";
            
            var name = type.Name();

            if (name.EndsWith(suffix, CurrentCultureIgnoreCase))
            {
                name = name.Remove(name.Length - suffix.Length);
            }
            
            ApiVersion = type.ApiVersion();
            Name = name;
            Type = type;
        }

        public ApiVersion ApiVersion { get; }
        
        public string Name { get; }

        public Type Type { get; }
    }
}