using MoviesApi.Exceptions;

namespace MoviesApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {

            _logger = logger;

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            //simplify code - in all places where we can get exception and clinet dont see our code if is exception
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e) 
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Something went wrong");
            }
        }
    }
}
