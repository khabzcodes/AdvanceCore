using AdvanceCore.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvanceCore.API.Filters;

public class ValidationFilterAttribute : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errorContext = context.ModelState.FirstOrDefault().Value;
            if (errorContext != null)
            {
                context.Result = new BadRequestObjectResult(new ErrorResponse()
                {
                    ErrorMessage = errorContext.Errors[0].ErrorMessage
                });
            }
        }
    }
}