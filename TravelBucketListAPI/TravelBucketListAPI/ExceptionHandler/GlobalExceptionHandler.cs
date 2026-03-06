using System.Text.Json;
using BusinessService.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TravelBucketListAPI.ExceptionHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
                _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var correlationId=Guid.NewGuid().ToString();

            var problemDetails = exception switch
            {
                NotFoundException ex => new ProblemDetails
                {
                    Title = "Not Found Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status404NotFound
                },
                _ => new ProblemDetails
                {
                    Title = "Unexpected Error",
                    Detail = exception.Message,
                    Status = StatusCodes.Status500InternalServerError
                }
            };

            var errorResponse = new
            {
                correlationId,
                timeStamp=DateTime.UtcNow,
                problem=problemDetails

            };

            httpContext.Response.StatusCode = problemDetails.Status ?? 500;
            httpContext.Response.ContentType = "application/json";
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, jsonOptions), cancellationToken);

            return true;
        }
    }
}
