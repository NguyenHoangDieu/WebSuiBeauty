namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        MenuUrl = c.String(),
                        ParentId = c.Int(),
                        SortOrder = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuItem");
        }
    }
}
