namespace IronTower.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Structures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Income = c.Int(nullable: false),
                        UpKeep = c.Int(nullable: false),
                        InitialCost = c.Int(nullable: false),
                        PopulationCost = c.Int(nullable: false),
                        IsResidence = c.Boolean(nullable: false),
                        SupportedPopulation = c.Int(nullable: false),
                        Game_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.Game_ID)
                .Index(t => t.Game_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "Game_ID", "dbo.Games");
            DropIndex("dbo.Structures", new[] { "Game_ID" });
            DropTable("dbo.Structures");
        }
    }
}
