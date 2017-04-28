using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MSIdentityStarter.Infrastructure;
using MSIdentityStarter.Models;

namespace MSIdentityStarter.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(loginModel.Name, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password");
                }
                else
                {
                    //IIdentity接口的ASP.NET Identity接口的ASP
                    ClaimsIdentity identity =
                        await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                    AuthManager.SignOut();
                    AuthManager.SignIn(
                        new AuthenticationProperties
                        {
                            IsPersistent = false,
                        }, identity);

                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(loginModel);
        }

    }
}