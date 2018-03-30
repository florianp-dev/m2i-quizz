namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
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
                        QuestionID = c.Int(nullable: false),
                        CommentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.AnswerComments", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID)
                .Index(t => t.CommentID);
            
            CreateTable(
                "dbo.AnswerComments",
                c => new
                    {
                        QCommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.QCommentID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        TechnoID = c.Int(nullable: false),
                        QTypeID = c.Int(nullable: false),
                        DifficultyID = c.Int(nullable: false),
                        Quizz_QuizzID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzID)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyID, cascadeDelete: true)
                .ForeignKey("dbo.QuestionTypes", t => t.QTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Technoes", t => t.TechnoID, cascadeDelete: true)
                .Index(t => t.TechnoID)
                .Index(t => t.QTypeID)
                .Index(t => t.DifficultyID)
                .Index(t => t.Quizz_QuizzID);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        DifficultyType = c.String(),
                    })
                .PrimaryKey(t => t.DifficultyID);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzID = c.Int(nullable: false, identity: true),
                        CandidateFirstname = c.String(),
                        CandidateLastname = c.String(),
                        UserID = c.Int(nullable: false),
                        TechnoID = c.Int(nullable: false),
                        MasterDifficultyID = c.Int(nullable: false),
                        ResultID = c.Int(nullable: false),
                        PercentID = c.Int(nullable: false),
                        Difficulty_DifficultyID = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzID)
                .ForeignKey("dbo.MasterDifficulties", t => t.MasterDifficultyID, cascadeDelete: true)
                .ForeignKey("dbo.Percents", t => t.PercentID, cascadeDelete: true)
                .ForeignKey("dbo.Results", t => t.ResultID, cascadeDelete: true)
                .ForeignKey("dbo.Technoes", t => t.TechnoID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Difficulties", t => t.Difficulty_DifficultyID)
                .Index(t => t.UserID)
                .Index(t => t.TechnoID)
                .Index(t => t.MasterDifficultyID)
                .Index(t => t.ResultID)
                .Index(t => t.PercentID)
                .Index(t => t.Difficulty_DifficultyID);
            
            CreateTable(
                "dbo.MasterDifficulties",
                c => new
                    {
                        MasterDifficultyID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        DifficultyType = c.String(),
                    })
                .PrimaryKey(t => t.MasterDifficultyID);
            
            CreateTable(
                "dbo.Percents",
                c => new
                    {
                        PercentID = c.Int(nullable: false, identity: true),
                        Beginner = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Intermediate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Expert = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PercentID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ResultID);
            
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
                "dbo.QuestionTypes",
                c => new
                    {
                        QTypeID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                    })
                .PrimaryKey(t => t.QTypeID);
            
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
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TechnoID", "dbo.Technoes");
            DropForeignKey("dbo.Questions", "QTypeID", "dbo.QuestionTypes");
            DropForeignKey("dbo.Questions", "DifficultyID", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "Difficulty_DifficultyID", "dbo.Difficulties");
            DropForeignKey("dbo.Quizzs", "UserID", "dbo.Users");
            DropForeignKey("dbo.Quizzs", "TechnoID", "dbo.Technoes");
            DropForeignKey("dbo.Quizzs", "ResultID", "dbo.Results");
            DropForeignKey("dbo.ResultAnswers", "Answer_AnswerID", "dbo.Answers");
            DropForeignKey("dbo.ResultAnswers", "Result_ResultID", "dbo.Results");
            DropForeignKey("dbo.Questions", "Quizz_QuizzID", "dbo.Quizzs");
            DropForeignKey("dbo.Quizzs", "PercentID", "dbo.Percents");
            DropForeignKey("dbo.Quizzs", "MasterDifficultyID", "dbo.MasterDifficulties");
            DropForeignKey("dbo.Answers", "CommentID", "dbo.AnswerComments");
            DropIndex("dbo.ResultAnswers", new[] { "Answer_AnswerID" });
            DropIndex("dbo.ResultAnswers", new[] { "Result_ResultID" });
            DropIndex("dbo.Quizzs", new[] { "Difficulty_DifficultyID" });
            DropIndex("dbo.Quizzs", new[] { "PercentID" });
            DropIndex("dbo.Quizzs", new[] { "ResultID" });
            DropIndex("dbo.Quizzs", new[] { "MasterDifficultyID" });
            DropIndex("dbo.Quizzs", new[] { "TechnoID" });
            DropIndex("dbo.Quizzs", new[] { "UserID" });
            DropIndex("dbo.Questions", new[] { "Quizz_QuizzID" });
            DropIndex("dbo.Questions", new[] { "DifficultyID" });
            DropIndex("dbo.Questions", new[] { "QTypeID" });
            DropIndex("dbo.Questions", new[] { "TechnoID" });
            DropIndex("dbo.Answers", new[] { "CommentID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.ResultAnswers");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Technoes");
            DropTable("dbo.Results");
            DropTable("dbo.Percents");
            DropTable("dbo.MasterDifficulties");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Questions");
            DropTable("dbo.AnswerComments");
            DropTable("dbo.Answers");
        }
    }
}
