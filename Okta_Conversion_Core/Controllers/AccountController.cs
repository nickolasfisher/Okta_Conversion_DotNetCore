using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Okta.AspNetCore;

namespace Okta_Conversion_Core.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public ActionResult LogOff()
        {
            return new SignOutResult(
                    new[]
                    {
                            OktaDefaults.MvcAuthenticationScheme,
                            CookieAuthenticationDefaults.AuthenticationScheme,
                    },
                    new AuthenticationProperties { RedirectUri = "/Home/" });

                    }
         }
}
