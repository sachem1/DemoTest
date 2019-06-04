using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public static class RequestIpScoreMiddleware
    {
        public static void UseRequestIpScore(this IApplicationBuilder app)
        {
            app.Use(RequestIpScoreHandler);
        }

        public static async Task RequestIpScoreHandler(HttpContext context,Func<Task> next)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
                if (!string.IsNullOrEmpty(ip))
                {
                    Console.WriteLine($"请求的IP地址是:{ip}");
                }
                else
                {
                    Console.WriteLine("请求来源异常!");
                    await context.Response.WriteAsync("请求来源异常!");
                }
            }
            await next();
        }

    }
}
