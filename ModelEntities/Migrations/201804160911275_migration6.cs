namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Quizz_QuizzID", "dbo.Quizzs");
            DropIndex("dbo.Questions", new[] { "Quizz_QuizzID" });
            DropColumn("dbo.Questions", "Quizz_QuizzID");
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        Quizz_QuizzID = c.Int(nullable: false),
                        Question_QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quizz_QuizzID, t.Question_QuestionID })
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionID, cascadeDelete: false)
                .Index(t => t.Quizz_QuizzID)
                .Index(t => t.Question_QuestionID);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Quizz_QuizzID", c => c.Int());
            DropForeignKey("dbo.QuizzQuestions", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "Quizz_QuizzID", "dbo.Quizzs");
            DropIndex("dbo.QuizzQuestions", new[] { "Question_QuestionID" });
            DropIndex("dbo.QuizzQuestions", new[] { "Quizz_QuizzID" });
            DropTable("dbo.QuizzQuestions");
            CreateIndex("dbo.Questions", "Quizz_QuizzID");
            AddForeignKey("dbo.Questions", "Quizz_QuizzID", "dbo.Quizzs", "QuizzID");
        }
    }
}
