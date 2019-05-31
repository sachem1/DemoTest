using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ModuleCommon.Middleware
{
    public class CustomAuthenticationOptions: AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; set; }
    }
}
