using System.Data.Entity.Migrations;

namespace ModelEntities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ModelEntities.Entities.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ModelEntities.Entities.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
