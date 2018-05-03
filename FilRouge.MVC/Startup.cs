using FilRouge.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using ModelEntities.Entities;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilRouge.Web.Startup))]
namespace FilRouge.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesandUsers()
        {
            var context = new DataBaseContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));
            
            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin role
                var roleAdmin = new IdentityRole();
                roleAdmin.Name = "Admin";
                roleManager.Create(roleAdmin);

                //Here we create a Admin super user who will maintain the website                  

                var user = new User();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";

                string userPWD = "Admin#1";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // Creating Agent role    
            if (!roleManager.RoleExists("Agent"))
            {
                var roleAgent = new IdentityRole();
                roleAgent.Name = "Agent";
                roleManager.Create(roleAgent);

                //Here we create a Agent user

                var user = new User();
                user.UserName = "agent@gmail.com";
                user.Email = "agent@gmail.com";

                string userPWD = "Agent#1";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Agent   
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Agent");
                }
            }
        }
    }
}
