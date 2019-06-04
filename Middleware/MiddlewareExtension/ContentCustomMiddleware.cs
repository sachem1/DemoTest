using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware.MiddlewareExtension
{
    public class ContentCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public ContentCustomMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("content"))
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("来自ContentCustomMiddleware 内容",Encoding.UTF8);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
