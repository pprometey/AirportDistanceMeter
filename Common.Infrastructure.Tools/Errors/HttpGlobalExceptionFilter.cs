using Common.Infrastructure.Tools.Errors.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;


namespace Common.Infrastructure.Tools.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(context.Exception.HResult),
                context.Exception, context.Exception.Message);

            switch (context.Exception)
            {
                case ValidationException:
                    context.Result = new BadRequestObjectResult(
                        (context.Exception as ValidationException).ToBadRequestObjectResult());
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    context.Result = new BadRequestObjectResult(context.Exception);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.ExceptionHandled = true;
        }
    }
}
