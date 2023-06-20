namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminEmployeeInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateofBirth = c.DateTime(),
                        Gender = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.EmpID);
            
            AddColumn("dbo.AdminLogins", "EmpID", c => c.Int(nullable: false));
            CreateIndex("dbo.AdminLogins", "EmpID");
            AddForeignKey("dbo.AdminLogins", "EmpID", "dbo.Employees", "EmpID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminLogins", "EmpID", "dbo.Employees");
            DropIndex("dbo.AdminLogins", new[] { "EmpID" });
            DropColumn("dbo.AdminLogins", "EmpID");
            DropTable("dbo.Employees");
        }
    }
}
