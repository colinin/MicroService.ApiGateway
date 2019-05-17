using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicroService.ApiGateway.Authentication;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;

namespace MicroService.ApiGateway.Controllers
{
    [Authorize]
    public class AccountController : AbpController
    {
        public IActionResult Logout()
        {
            return new SignOutResult(new List<string> { AuthenticationConsts.CookieName, AuthenticationConsts.OidcAuthenticationScheme },
                new AuthenticationProperties { RedirectUri = "/" });
        }
    }
}
