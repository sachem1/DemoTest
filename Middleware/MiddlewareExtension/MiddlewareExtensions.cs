using Microsoft.AspNetCore.Builder;

namespace Middleware.MiddlewareExtension
{
    /// <summary>
    /// 
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestIpScore(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestIpScoreMiddleware>();
        }

        public static IApplicationBuilder UseContentCustomMiddleware(this IApplicationBuilder app)
        {
           return app.UseMiddleware(typeof(ContentCustomMiddleware));
        }

        public static IApplicationBuilder UserAuthCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthCustomMiddleware>();
        }
    }
}
