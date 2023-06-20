namespace WebSuiBeauty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 250),
                        Website = c.String(maxLength: 250),
                        Address = c.String(maxLength: 250),
                        Other = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContentCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(maxLength: 500),
                        ParentId = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        MetaKeywords = c.String(maxLength: 256),
                        MetaDescriptions = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        Description = c.String(maxLength: 500),
                        Post = c.String(),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        MetaKeywords = c.String(maxLength: 256),
                        MetaDescriptions = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ContentTag",
                c => new
                    {
                        ContentId = c.Int(nullable: false),
                        TagId = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ContentId, t.TagId })
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ContentId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Message = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 256),
                        CustomerAddress = c.String(nullable: false, maxLength: 256),
                        CustomerEmail = c.String(nullable: false, maxLength: 256),
                        CustomerMobile = c.String(nullable: false, maxLength: 50),
                        CustomerMessage = c.String(nullable: false, maxLength: 256),
                        PaymentMethod = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        PaymentStatus = c.String(),
                        Status = c.Boolean(nullable: false),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warranty = c.Int(),
                        Description = c.String(maxLength: 500),
                        ViewCount = c.Int(),
                        Quantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        MetaKeywords = c.String(maxLength: 256),
                        MetaDescriptions = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 500),
                        ParentId = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 256),
                        MetaKeywords = c.String(maxLength: 256),
                        MetaDescriptions = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTag",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        TagId = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.TagId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.ProductTag", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ContentTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.ContentTag", "ContentId", "dbo.Content");
            DropForeignKey("dbo.Content", "CategoryId", "dbo.ContentCategory");
            DropIndex("dbo.ProductTag", new[] { "TagId" });
            DropIndex("dbo.ProductTag", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.ContentTag", new[] { "TagId" });
            DropIndex("dbo.ContentTag", new[] { "ContentId" });
            DropIndex("dbo.Content", new[] { "CategoryId" });
            DropTable("dbo.ProductTag");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.FeedBack");
            DropTable("dbo.Tag");
            DropTable("dbo.ContentTag");
            DropTable("dbo.Content");
            DropTable("dbo.ContentCategory");
            DropTable("dbo.ContactDetail");
        }
    }
}
