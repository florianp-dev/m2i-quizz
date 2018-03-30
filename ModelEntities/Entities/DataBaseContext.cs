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
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionComment> QComments { get; set; }
        public DbSet<QuestionType> QTypes { get; set; }
        public DbSet<Quizz> Quizzes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Techno> Technos { get; set; }
        public DbSet<User> Users { get; set; }

        public DataBaseContext() : base("QuizzApplication")
        {
            //Pour la création de la base
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataBaseContext>());

            //Pour la migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Migrations.Configuration>()); 
            
        }
    }
}
