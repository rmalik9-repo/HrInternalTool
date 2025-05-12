using Microsoft.AspNetCore.Mvc;

namespace HrInternalTool.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _requestDelegate = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try {
            await _requestDelegate(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,exception.Message);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error"
                };
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
