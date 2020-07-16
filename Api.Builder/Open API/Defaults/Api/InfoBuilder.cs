using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using static System.Configuration.ConfigurationManager;


namespace Api.Builder
{
    public class InfoBuilder : ApiBuilder<ApiVersion, OpenApiInfo>
    {
        protected internal override OpenApiInfo CreateValue(ApiVersion apiVersion, Dictionary<string, OpenApiSchema> schemaRegistry)
        {
            return new OpenApiInfo
            {
                Title = AppSettings["Title"],
                Description = AppSettings["Description"],
                Contact = new OpenApiContact
                {
                    Name = AppSettings["Name"],
                    Email = AppSettings["Email"]
                },
                Version = apiVersion.ToString()
            };
        }
    }
}