using Microsoft.AspNet.Identity;
using ModelEntities.Entities;

namespace ModelEntities.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBaseContext context)
        {
            context.Roles.AddOrUpdate(new IdentityRole("Admin"));
            context.Roles.AddOrUpdate(new IdentityRole("Recruitment Agent"));

            var admin = new User
            {
                UserName = "admin",
                FirstName = "Admin",
                LastName = "User",
                Email = "xxx@xxx.net",
                PhoneNumber = "5551234567"
            };
            var rAgent = new User
            {
                UserName = "Recruitment Agent",
                FirstName = "Recruitment",
                LastName = "Agent",
                Email = "xxx@xxx.net",
                PhoneNumber = "5551234567"
            };

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            
            // mot de passe "admin"
            userManager.Create(admin, "admin");
            userManager.SetLockoutEnabled(admin.Id, false);
            userManager.AddToRole(admin.Id, "Admin");
            // mot de passe "agent"
            userManager.Create(rAgent, "agent");
            userManager.SetLockoutEnabled(rAgent.Id, false);
            userManager.AddToRole(admin.Id, "Recruitment Agent");
        }
    }
}
