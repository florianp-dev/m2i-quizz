namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quizzs", "Difficulty_DifficultyID", "dbo.Difficulties");
            DropIndex("dbo.Quizzs", new[] { "Difficulty_DifficultyID" });
            DropColumn("dbo.Quizzs", "Difficulty_DifficultyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizzs", "Difficulty_DifficultyID", c => c.Int());
            CreateIndex("dbo.Quizzs", "Difficulty_DifficultyID");
            AddForeignKey("dbo.Quizzs", "Difficulty_DifficultyID", "dbo.Difficulties", "DifficultyID");
        }
    }
}
