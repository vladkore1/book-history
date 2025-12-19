using BookHistory.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BookHistory.Api.ExceptionHandlers
{
    public class AppExceptionHandler(IProblemDetailsService pdService) : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService = pdService;

        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is AppException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
                {
                    HttpContext = context,
                    ProblemDetails =
                    {
                        Title = "Error",
                        Detail = ex.Message,
                        Status = ex.StatusCode,
                        Instance = context.Request.Path
                    }
                });
                return true;
            }

            return false;
        }
    }
}
