namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCreation : DbMigration
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
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyID, cascadeDelete: true)
                .ForeignKey("dbo.QuestionTypes", t => t.QTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Technoes", t => t.TechnoID, cascadeDelete: true)
                .Index(t => t.TechnoID)
                .Index(t => t.QTypeID)
                .Index(t => t.DifficultyID);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        DifficultyID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        PercentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DifficultyID)
                .ForeignKey("dbo.Percents", t => t.PercentID, cascadeDelete: true)
                .Index(t => t.PercentID);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzID = c.Int(nullable: false, identity: true),
                        CandidateFirstname = c.String(),
                        CandidateLastname = c.String(),
                        NbQuestions = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        TechnoID = c.Int(nullable: false),
                        DifficultyID = c.Int(nullable: false),
                        ResultID = c.Int(),
                    })
                .PrimaryKey(t => t.QuizzID)
                .ForeignKey("dbo.Difficulties", t => t.DifficultyID, cascadeDelete: true)
                .ForeignKey("dbo.Results", t => t.ResultID)
                .ForeignKey("dbo.Technoes", t => t.TechnoID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.TechnoID)
                .Index(t => t.DifficultyID)
                .Index(t => t.ResultID);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Society = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.QuestionTypes",
                c => new
                    {
                        QTypeID = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                    })
                .PrimaryKey(t => t.QTypeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TechnoID", "dbo.Technoes");
            DropForeignKey("dbo.Questions", "QTypeID", "dbo.QuestionTypes");
            DropForeignKey("dbo.Questions", "DifficultyID", "dbo.Difficulties");
            DropForeignKey("dbo.Difficulties", "PercentID", "dbo.Percents");
            DropForeignKey("dbo.Quizzs", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quizzs", "TechnoID", "dbo.Technoes");
            DropForeignKey("dbo.Quizzs", "ResultID", "dbo.Results");
            DropForeignKey("dbo.ResultAnswers", "Answer_AnswerID", "dbo.Answers");
            DropForeignKey("dbo.ResultAnswers", "Result_ResultID", "dbo.Results");
            DropForeignKey("dbo.QuizzQuestions", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "Quizz_QuizzID", "dbo.Quizzs");
            DropForeignKey("dbo.Quizzs", "DifficultyID", "dbo.Difficulties");
            DropForeignKey("dbo.Answers", "CommentID", "dbo.AnswerComments");
            DropIndex("dbo.ResultAnswers", new[] { "Answer_AnswerID" });
            DropIndex("dbo.ResultAnswers", new[] { "Result_ResultID" });
            DropIndex("dbo.QuizzQuestions", new[] { "Question_QuestionID" });
            DropIndex("dbo.QuizzQuestions", new[] { "Quizz_QuizzID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Quizzs", new[] { "ResultID" });
            DropIndex("dbo.Quizzs", new[] { "DifficultyID" });
            DropIndex("dbo.Quizzs", new[] { "TechnoID" });
            DropIndex("dbo.Quizzs", new[] { "UserID" });
            DropIndex("dbo.Difficulties", new[] { "PercentID" });
            DropIndex("dbo.Questions", new[] { "DifficultyID" });
            DropIndex("dbo.Questions", new[] { "QTypeID" });
            DropIndex("dbo.Questions", new[] { "TechnoID" });
            DropIndex("dbo.Answers", new[] { "CommentID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.ResultAnswers");
            DropTable("dbo.QuizzQuestions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Percents");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Technoes");
            DropTable("dbo.Results");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Questions");
            DropTable("dbo.AnswerComments");
            DropTable("dbo.Answers");
        }
    }
}
