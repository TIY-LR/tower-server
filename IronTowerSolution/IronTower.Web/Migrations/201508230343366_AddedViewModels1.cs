namespace IronTower.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "TotalBalance", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "CurrencyAccrued");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "CurrencyAccrued", c => c.Int(nullable: false));
            DropColumn("dbo.Games", "TotalBalance");
        }
    }
}
