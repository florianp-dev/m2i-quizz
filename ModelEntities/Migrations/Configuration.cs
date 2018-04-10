namespace ModelEntities.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelEntities.Entities.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ModelEntities.Entities.DataBaseContext context)
        {
            context.Roles.AddOrUpdate(new IdentityRole("Admin"));
            context.Roles.AddOrUpdate(new IdentityRole("Recruitment Agent"));
        }
    }
}
