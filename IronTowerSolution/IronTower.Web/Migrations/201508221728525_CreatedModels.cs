namespace IronTower.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Floor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Floor", c => c.Int(nullable: false));
        }
    }
}
