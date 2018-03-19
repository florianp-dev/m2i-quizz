namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        LinkedQuestion_QuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.LinkedQuestion_QuestionID)
                .Index(t => t.LinkedQuestion_QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Difficulty_DifficultyID = c.Int(),
                        QType_QTypeID = c.Int(),
                        Techno_TechnoID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Difficulties", t => t.Difficulty_DifficultyID)
                .ForeignKey("dbo.QuestionTypes", t => t.QType_QTypeID)
                .ForeignKey("dbo.Technoes", t => t.Techno_TechnoID)
                .Index(t => t.Difficulty_DifficultyID)
                .Index(t => t.QType_QTypeID)
                .Index(t => t.Techno_TechnoID);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DifficultyID);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzID = c.Int(nullable: false, identity: true),
                        CandidateFirstname = c.String(),
                        CandidateLastname = c.String(),
                        Difficulty_DifficultyID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzID)
                .ForeignKey("dbo.Difficulties", t => t.Difficulty_DifficultyID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Difficulty_DifficultyID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ResultID)
                .ForeignKey("dbo.Quizzs", t => t.ResultID)
                .Index(t => t.ResultID);
            
            CreateTable(
                "dbo.QuestionComments",
                c => new
                    {
                        QCommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.QCommentID)
                .ForeignKey("dbo.Questions", t => t.QCommentID)
                .Index(t => t.QCommentID);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QTypeID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                    })
                .PrimaryKey(t => t.QTypeID);
            
            CreateTable(
                "dbo.Technoes",
                c => new
                    {
                        TechnoID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                    })
                .PrimaryKey(t => t.TechnoID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Tel = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        Society = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.ResultAnswers",
                c => new
                    {
                        Result_ResultID = c.Int(nullable: false),
                        Answer_AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Result_ResultID, t.Answer_AnswerID })
                .ForeignKey("dbo.Results", t => t.Result_ResultID, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerID, cascadeDelete: true)
                .Index(t => t.Result_ResultID)
                .Index(t => t.Answer_AnswerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizzs", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Questions", "Techno_TechnoID", "dbo.Technoes");
            DropForeignKey("dbo.Questions", "QType_QTypeID", "dbo.QuestionTypes");
            DropForeignKey("dbo.Answers", "LinkedQuestion_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.QuestionComments", "QCommentID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Difficulty_DifficultyID", "dbo.Difficulties");
            DropForeignKey("dbo.Results", "ResultID", "dbo.Quizzs");
            DropForeignKey("dbo.ResultAnswers", "Answer_AnswerID", "dbo.Answers");
            DropForeignKey("dbo.ResultAnswers", "Result_ResultID", "dbo.Results");
            DropForeignKey("dbo.Quizzs", "Difficulty_DifficultyID", "dbo.Difficulties");
            DropIndex("dbo.ResultAnswers", new[] { "Answer_AnswerID" });
            DropIndex("dbo.ResultAnswers", new[] { "Result_ResultID" });
            DropIndex("dbo.QuestionComments", new[] { "QCommentID" });
            DropIndex("dbo.Results", new[] { "ResultID" });
            DropIndex("dbo.Quizzs", new[] { "User_UserID" });
            DropIndex("dbo.Quizzs", new[] { "Difficulty_DifficultyID" });
            DropIndex("dbo.Questions", new[] { "Techno_TechnoID" });
            DropIndex("dbo.Questions", new[] { "QType_QTypeID" });
            DropIndex("dbo.Questions", new[] { "Difficulty_DifficultyID" });
            DropIndex("dbo.Answers", new[] { "LinkedQuestion_QuestionID" });
            DropTable("dbo.ResultAnswers");
            DropTable("dbo.Users");
            DropTable("dbo.Technoes");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.QuestionComments");
            DropTable("dbo.Results");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
