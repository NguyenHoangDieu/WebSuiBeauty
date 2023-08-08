namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "CustomerId", c => c.String(maxLength: 128));
        }
    }
}
