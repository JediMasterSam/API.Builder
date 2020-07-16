using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Builder
{
    public class ErrorResult : ObjectResult
    {
        public ErrorResult(ModelStateDictionary modelState) : base(new ErrorResponse(modelState))
        {
            StatusCode = 400;
        }

        public ErrorResult(Exception exception) : base(new ErrorResponse(exception))
        {
            StatusCode = 500;
        }
    }
}