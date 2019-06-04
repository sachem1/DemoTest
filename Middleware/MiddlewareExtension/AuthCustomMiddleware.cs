using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware.MiddlewareExtension
{
    public class AuthCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("customer"))
            {
                var querystring = context.Request.QueryString.ToString();
                querystring = querystring.Substring(1, querystring.Length - 1);
                string userName = "", password = "";
                if (!string.IsNullOrEmpty(querystring))
                {
                    var paramArr = querystring.Split('&');
                    foreach (var item in paramArr)
                    {
                        var param = item.Split('=');
                        if (param[0] == "userName")
                            userName = param[1];
                        if (param[0] == "password")
                            password = param[1];
                    }

                    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("用户不合法");
                    }
                }
                else
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("用户不合法");
                }
            }

            await _next.Invoke(context);
        }
    }
}
