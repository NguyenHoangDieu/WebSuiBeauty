using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebSuiBeauty.Data
{
    public class WebSuiBeautyDbContext : DbContext
    {
        public WebSuiBeautyDbContext() : base ("name=DbContext") {}
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentTag> ContentTags { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
    
}