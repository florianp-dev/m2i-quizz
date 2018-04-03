namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quizznbQuestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizzs", "NbQuestions", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizzs", "NbQuestions");
        }
    }
}
