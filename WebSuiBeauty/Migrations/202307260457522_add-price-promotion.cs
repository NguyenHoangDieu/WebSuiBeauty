namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpricepromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "PriceAfterPromotion", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "PriceAfterPromotion");
        }
    }
}
