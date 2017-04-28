using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MSIdentityStarter.Infrastructure
{
    public class AppIdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context); base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            // initial configuration will go here
        }
    }
}