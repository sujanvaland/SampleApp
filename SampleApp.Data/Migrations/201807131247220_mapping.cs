namespace SampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapping : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerAddresses", newName: "CustomerAddress");
            RenameTable(name: "dbo.Customers", newName: "Customer");
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        IsShiped = c.Boolean(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AlterColumn("dbo.CustomerAddress", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerAddress", "Address2", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerAddress", "City", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(maxLength: 500));
            CreateIndex("dbo.CustomerAddress", "CustomerId");
            AddForeignKey("dbo.CustomerAddress", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CustomerAddress", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.CustomerAddress", new[] { "CustomerId" });
            AlterColumn("dbo.Customer", "CustomerName", c => c.String());
            AlterColumn("dbo.CustomerAddress", "City", c => c.String());
            AlterColumn("dbo.CustomerAddress", "Address2", c => c.String());
            AlterColumn("dbo.CustomerAddress", "Address1", c => c.String());
            DropTable("dbo.Orders");
            RenameTable(name: "dbo.Customer", newName: "Customers");
            RenameTable(name: "dbo.CustomerAddress", newName: "CustomerAddresses");
        }
    }
}
