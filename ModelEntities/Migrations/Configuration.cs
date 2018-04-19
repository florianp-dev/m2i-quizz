using ModelEntities.Entities;
using System.Data.Entity.Migrations;
namespace ModelEntities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBaseContext context)
        {
            
        }
    }
}
