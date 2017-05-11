using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MSIdentityStarter.Models;

namespace MSIdentityStarter.Infrastructure
{
    public class AppIdentityDbInit 
        : NullDatabaseInitializer<AppIdentityDbContext>
        //: DropCreateDatabaseIfModelChanges<AppIdentityDbContext>  //会在Code First类改变时删除整个数据库
    {
        //protected override void Seed(AppIdentityDbContext context)
        //{
        //    PerformInitialSetup(context);
        //    base.Seed(context);
        //}

        //public void PerformInitialSetup(AppIdentityDbContext context)
        //{

        //}
    }
}