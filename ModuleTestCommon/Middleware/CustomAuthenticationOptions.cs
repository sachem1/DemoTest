using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace ModuleTestCommon.Middleware
{
    public class CustomAuthenticationOptions: AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; set; }
    }
}
