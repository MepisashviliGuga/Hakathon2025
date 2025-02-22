using Hakathon.API.infrastructure.middlewares;

namespace Hakathon.API.infrastructure.extensions
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            return app;
        }
    }
}