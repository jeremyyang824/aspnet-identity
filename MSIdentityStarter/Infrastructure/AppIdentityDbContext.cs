using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MSIdentityStarter.Models;

namespace MSIdentityStarter.Infrastructure
{
    /// <summary>
    /// 基于EF的IdentityDbContext
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("MSIdentityDb") { }

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new AppIdentityDbInit());
        }

        /// <summary>
        /// AppIdentityDbContext工厂
        /// </summary>
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}