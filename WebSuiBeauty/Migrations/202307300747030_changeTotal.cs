namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetail", "TotalAll", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetail", "TotalAll");
        }
    }
}
