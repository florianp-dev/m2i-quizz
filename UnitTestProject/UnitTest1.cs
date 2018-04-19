using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelEntities.Entities;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddUserAndRoles()
        {
            var context = new DataBaseContext();

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole("Admin"));
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole("Recruitment Agent"));

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
                Email = "yyy@xxx.net",
                PhoneNumber = "5551234568"
            };

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            // mot de passe "admin"
            userManager.Create(admin, "Admin#1");
            context.SaveChanges();
            userStore.AddToRoleAsync(admin, "Admin").Wait();

            // mot de passe "agent"
            userManager.Create(rAgent, "Agent#1");
            //context.SaveChanges();
            userStore.AddToRoleAsync(rAgent, "Recruitment Agent").Wait();
        }
    }
}
