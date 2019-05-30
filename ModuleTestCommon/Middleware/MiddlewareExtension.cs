using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace ModuleTestCommon.Middleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDemoMiddleware(IApplicationBuilder app)
        {
            return app.UseMiddleware<DemoMiddleware>();
        }
    }
}
