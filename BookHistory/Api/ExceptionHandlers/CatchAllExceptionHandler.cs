using Microsoft.AspNetCore.Diagnostics;

namespace BookHistory.Api.ExceptionHandlers
{
    public class CatchAllExceptionHandler(IProblemDetailsService pdService) : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService = pdService;

        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = context,
                ProblemDetails =
                    {
                        Title = "Internal Server Error",
                        Detail = "There was a server error.",
                        Status = StatusCodes.Status500InternalServerError,
                    }
            });
            return true;
        }
    }
}
