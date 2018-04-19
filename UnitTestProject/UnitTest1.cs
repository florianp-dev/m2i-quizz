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

            context.SaveChanges();

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

            context.Users.AddOrUpdate(u => u.UserName, admin);
            context.Users.AddOrUpdate(u => u.UserName, rAgent);

            context.SaveChanges();

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            userStore.AddToRoleAsync(admin, "Admin").Wait();
            userStore.AddToRoleAsync(rAgent, "Recruitment Agent").Wait();


            context.SaveChanges();

            // mot de passe "admin"
            /*userManager.Create(admin, "Admin#1");
            userStore.AddToRoleAsync(admin, "Admin").Wait();

            // mot de passe "agent"
            userManager.Create(rAgent, "Agent#1");
            userStore.AddToRoleAsync(rAgent, "Recruitment Agent").Wait();*/
        }
    }
}
