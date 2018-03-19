namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialv19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "LinkedQuestion_QuestionID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "LinkedQuestion_QuestionID" });
            RenameColumn(table: "dbo.Quizzs", name: "User_UserID", newName: "LinkedUser_UserID");
            RenameIndex(table: "dbo.Quizzs", name: "IX_User_UserID", newName: "IX_LinkedUser_UserID");
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        Quizz_QuizzID = c.Int(nullable: false),
                        Question_QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quizz_QuizzID, t.Question_QuestionID })
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionID, cascadeDelete: true)
                .Index(t => t.Quizz_QuizzID)
                .Index(t => t.Question_QuestionID);
            
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        Question_QuestionID = c.Int(nullable: false),
                        Answer_AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionID, t.Answer_AnswerID })
                .ForeignKey("dbo.Questions", t => t.Question_QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerID, cascadeDelete: true)
                .Index(t => t.Question_QuestionID)
                .Index(t => t.Answer_AnswerID);
            
            DropColumn("dbo.Answers", "LinkedQuestion_QuestionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "LinkedQuestion_QuestionID", c => c.Int());
            DropForeignKey("dbo.QuestionAnswers", "Answer_AnswerID", "dbo.Answers");
            DropForeignKey("dbo.QuestionAnswers", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "Quizz_QuizzID", "dbo.Quizzs");
            DropIndex("dbo.QuestionAnswers", new[] { "Answer_AnswerID" });
            DropIndex("dbo.QuestionAnswers", new[] { "Question_QuestionID" });
            DropIndex("dbo.QuizzQuestions", new[] { "Question_QuestionID" });
            DropIndex("dbo.QuizzQuestions", new[] { "Quizz_QuizzID" });
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.QuizzQuestions");
            RenameIndex(table: "dbo.Quizzs", name: "IX_LinkedUser_UserID", newName: "IX_User_UserID");
            RenameColumn(table: "dbo.Quizzs", name: "LinkedUser_UserID", newName: "User_UserID");
            CreateIndex("dbo.Answers", "LinkedQuestion_QuestionID");
            AddForeignKey("dbo.Answers", "LinkedQuestion_QuestionID", "dbo.Questions", "QuestionID");
        }
    }
}
