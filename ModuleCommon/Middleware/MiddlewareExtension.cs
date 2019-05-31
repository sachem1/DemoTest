using Microsoft.AspNetCore.Builder;

namespace ModuleCommon.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDemoMiddleware(IApplicationBuilder app)
        {
            return app.UseMiddleware<DemoMiddleware>();
        }
    }
}
