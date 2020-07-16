using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Api.Builder
{
    public sealed class ErrorResponse
    {
        internal ErrorResponse(ModelStateDictionary modelState)
        {
            Code = "400";
            Messages = modelState.Values.SelectMany(entry => entry.Errors.Select(modelError => new ErrorMessage(modelError)));
        }

        internal ErrorResponse(Exception exception)
        {
            Code = "500";
            Messages = new[] {new ErrorMessage(exception)};
        }

        [JsonProperty] public string Code { get; }

        [JsonProperty] public IEnumerable<ErrorMessage> Messages { get; }
    }
}