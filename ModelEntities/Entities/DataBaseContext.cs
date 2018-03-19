/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Créé le context nécessaire à notre application
/// </summary>

using System.Data.Entity;

namespace ModelEntities.Entities
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("QuizzApplication")
        {
            //Pour la création de la base
            Database.SetInitializer(new DropCreateDatabaseAlways<DataBaseContext>());
            
            //Pour la migration
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, System.Data.Entity.Migrations.Configuration>()); 
        }
    }
}
