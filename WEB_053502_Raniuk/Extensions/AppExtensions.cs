using Microsoft.AspNetCore.Builder;
using WEB_Raniuk_053502.Middleware;

namespace WEB_Raniuk_053502.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}