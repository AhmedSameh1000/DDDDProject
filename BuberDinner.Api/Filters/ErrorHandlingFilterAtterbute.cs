using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters
{
    public class ErrorHandlingFilterAtterbute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var Exception = context.Exception;
            var ProblemDetails = new ProblemDetails()
            {
                Title = "An error while proccesing your request",
                Status = StatusCodes.Status500InternalServerError,
            };
            context.Result = new ObjectResult(ProblemDetails);
            context.ExceptionHandled = true;
        }
    }
}
