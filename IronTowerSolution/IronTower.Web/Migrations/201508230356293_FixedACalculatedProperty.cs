namespace IronTower.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedACalculatedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PeriodicRevenue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "PeriodicRevenue");
        }
    }
}
