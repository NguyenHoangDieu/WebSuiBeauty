namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminLoginDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleType = c.Int(),
                        Notes = c.String(),
                        Role_RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_RoleID)
                .Index(t => t.Role_RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminLogins", "Role_RoleID", "dbo.Roles");
            DropIndex("dbo.AdminLogins", new[] { "Role_RoleID" });
            DropTable("dbo.Roles");
            DropTable("dbo.AdminLogins");
        }
    }
}
