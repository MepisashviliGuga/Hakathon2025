using Hakathon.API.infrastructure.middlewares;

namespace Hakathon.API.infrastructure.extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app) 
        {
            app.UseMiddleware<CultureMiddleware>();
            return app;
        }
    }
}
