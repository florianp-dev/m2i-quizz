/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Créé le context nécessaire à notre application
/// </summary>

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ModelEntities.ModelViews;

namespace ModelEntities.Entities
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerComment> QComments { get; set; }
        public DbSet<QuestionType> QTypes { get; set; }
        public DbSet<Quizz> Quizzes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Techno> Technos { get; set; }
        public DbSet<User> QuizzUsers { get; set; }
        public DbSet<MasterDifficulty> MasterDifficulties { get; set; }
        public DbSet<Percent> Percents { get; set; }


        public DataBaseContext() : base("QuizzApplication")
        {
            //Pour la création de la base
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataBaseContext>());

            //Pour la migration
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Migrations.Configuration>()); 
        }

        public static DataBaseContext Create()
        {
           return new DataBaseContext();
        }
    }
}
