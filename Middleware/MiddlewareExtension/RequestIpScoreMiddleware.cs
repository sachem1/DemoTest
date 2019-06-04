using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware.MiddlewareExtension
{
    public  class RequestIpScoreMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestIpScoreMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            RequestIpScoreMiddleware requestIpScoreMiddleware = this;
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
                if (!string.IsNullOrEmpty(ip))
                {
                    Console.WriteLine($"请求的IP地址是:{ip}");
                    requestIpScoreMiddleware.Test();
                }
                else
                {
                    Console.WriteLine("请求来源异常!");
                    await context.Response.WriteAsync("请求来源异常!");
                }
            }
            await this._next.Invoke(context);
        }

        private void Test()
        {
            Console.WriteLine("test");
        }

    }
}
