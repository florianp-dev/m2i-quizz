namespace ModelEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class difficulties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quizzs", "PercentID", "dbo.Percents");
            DropIndex("dbo.Quizzs", new[] { "PercentID" });
            AddColumn("dbo.MasterDifficulties", "PercentID", c => c.Int(nullable: false));
            CreateIndex("dbo.MasterDifficulties", "PercentID");
            AddForeignKey("dbo.MasterDifficulties", "PercentID", "dbo.Percents", "PercentID", cascadeDelete: true);
            DropColumn("dbo.Difficulties", "DifficultyType");
            DropColumn("dbo.Quizzs", "PercentID");
            DropColumn("dbo.MasterDifficulties", "DifficultyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MasterDifficulties", "DifficultyType", c => c.String());
            AddColumn("dbo.Quizzs", "PercentID", c => c.Int(nullable: false));
            AddColumn("dbo.Difficulties", "DifficultyType", c => c.String());
            DropForeignKey("dbo.MasterDifficulties", "PercentID", "dbo.Percents");
            DropIndex("dbo.MasterDifficulties", new[] { "PercentID" });
            DropColumn("dbo.MasterDifficulties", "PercentID");
            CreateIndex("dbo.Quizzs", "PercentID");
            AddForeignKey("dbo.Quizzs", "PercentID", "dbo.Percents", "PercentID", cascadeDelete: true);
        }
    }
}
