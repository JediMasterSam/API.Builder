using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Api.Builder
{
    public sealed class ErrorMessage
    {
        internal ErrorMessage(ModelError modelError)
        {
            Value = modelError.ErrorMessage;
            StackTrace = modelError.Exception?.StackTrace;
        }

        internal ErrorMessage(Exception exception)
        {
            Value = exception.Message;
            StackTrace = exception.StackTrace;
        }

        [JsonProperty] public string Value { get; }

        [JsonProperty] public string StackTrace { get; }
    }
}