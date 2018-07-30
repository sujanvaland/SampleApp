namespace SampleApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Customer_Roles_Mapping",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        Roles_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Roles_RoleId })
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Roles_RoleId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Roles_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer_Roles_Mapping", "Roles_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Customer_Roles_Mapping", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.Customer_Roles_Mapping", new[] { "Roles_RoleId" });
            DropIndex("dbo.Customer_Roles_Mapping", new[] { "Customer_CustomerId" });
            DropTable("dbo.Customer_Roles_Mapping");
            DropTable("dbo.Roles");
        }
    }
}
