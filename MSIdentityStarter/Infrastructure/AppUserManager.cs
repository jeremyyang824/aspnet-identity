using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MSIdentityStarter.Models;

namespace MSIdentityStarter.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        { }

        /// <summary>
        /// UserManager工厂方法
        /// </summary>
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            //IOwinContext实现定义了一个泛型的Get方法，它会返回已经在OWIN启动类中注册的对象实例
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();
            //UserStore<T>类是IUserStore<T>接口的EntityFramework实现，它提供了UserManager类所定义的存储方法的实现
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));

            //使用内建密码验证器
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = false,
            //    RequireDigit = false,
            //    RequireLowercase = false,
            //    RequireUppercase = false
            //};

            //使用自定义密码验证器
            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            //使用内建用户验证器
            //manager.UserValidator = new UserValidator<AppUser>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = true,
            //    RequireUniqueEmail = true
            //};

            //使用自定义用户验证器
            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            return manager;
        }
    }
}