using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Builder
{
    public class ControllerReader : ApiReader<Type, ControllerInfo>
    {
        protected override bool TryGetValue(Type type, out ControllerInfo controller)
        {
            if (!typeof(ControllerBase).IsAssignableFrom(type) || type.Obsolete())
            {
                controller = null;
                return false;
            }

            controller = new ControllerInfo(type);

            return controller.ApiVersion != null;
        }
    }
}