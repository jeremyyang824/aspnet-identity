using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using MSIdentityStarter.Models;

namespace MSIdentityStarter.Infrastructure
{
    /// <summary>
    /// 自定义用户验证器
    /// </summary>
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(UserManager<AppUser, string> manager)
            : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            if (!user.Email.ToLower().EndsWith("@example.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Only example.com email addresses are allowed");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}