using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Builder
{
    public sealed class ErrorFilter : IActionFilter, IExceptionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ErrorResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null) return;

            context.Result = new ErrorResult(context.Exception);
            context.Exception = null;
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new ErrorResult(context.Exception);
            context.Exception = null;
        }
    }
}