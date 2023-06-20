namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class custommer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Avatar = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        MetaKeywords = c.String(maxLength: 256),
                        MetaDescriptions = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
