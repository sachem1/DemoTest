using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ModuleCommon.Middleware
{
    public class DemoMiddleware
    {
        private readonly RequestDelegate _next;

        public DemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity == null || string.IsNullOrEmpty(context.User.Identity.Name))
            {
                context.Response.Redirect("/Login.html");
                return;
            }
            await _next.Invoke(context);
        }
    }
}
