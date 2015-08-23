namespace IronTower.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedFirstModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrencyAccrued = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "Game_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Game_ID");
            AddForeignKey("dbo.AspNetUsers", "Game_ID", "dbo.Games", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Game_ID", "dbo.Games");
            DropIndex("dbo.AspNetUsers", new[] { "Game_ID" });
            DropColumn("dbo.AspNetUsers", "Game_ID");
            DropTable("dbo.Games");
        }
    }
}
