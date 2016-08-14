namespace CrunchyGranola2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        DateOfLastPurchase = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        UpcCode = c.Int(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        LeadTime = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false),
                        DepartmentName = c.String(),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                        DepartmentName = c.String(),
                        DepartmentID = c.Int(),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .ForeignKey("dbo.Department", t => t.Department_DepartmentID)
                .Index(t => t.DepartmentID)
                .Index(t => t.Department_DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Employee", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Purchase", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Employee", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Employee", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "EmployeeID" });
            DropIndex("dbo.Product", new[] { "DepartmentID" });
            DropIndex("dbo.Purchase", new[] { "ProductID" });
            DropIndex("dbo.Purchase", new[] { "CustomerID" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Product");
            DropTable("dbo.Purchase");
            DropTable("dbo.Customer");
        }
    }
}
