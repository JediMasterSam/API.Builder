using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Api.Builder
{
    public class TagBuilder : ApiBuilder<ControllerInfo, IList<OpenApiTag>>
    {
        protected internal override IList<OpenApiTag> CreateValue(ControllerInfo controller, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            return new List<OpenApiTag> {new OpenApiTag {Name = controller.Name}};
        }
    }
}