namespace SampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerAddresses", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerAddresses", new[] { "Customer_CustomerId" });
            AddColumn("dbo.CustomerAddresses", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerAddresses", "Customer_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerAddresses", "Customer_CustomerId", c => c.Int());
            DropColumn("dbo.CustomerAddresses", "CustomerId");
            CreateIndex("dbo.CustomerAddresses", "Customer_CustomerId");
            AddForeignKey("dbo.CustomerAddresses", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
