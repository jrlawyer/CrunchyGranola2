namespace CrunchyGranola2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        EmployeeID = c.Int(),
                        Manager_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Employee", t => t.Manager_EmployeeID)
                .Index(t => t.Manager_EmployeeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                        DepartmentName = c.String(),
                        Department_DepartmentID = c.Int(),
                        Department_DepartmentID1 = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Department", t => t.Department_DepartmentID)
                .ForeignKey("dbo.Department", t => t.Department_DepartmentID1)
                .Index(t => t.Department_DepartmentID)
                .Index(t => t.Department_DepartmentID1);

            //Create a department for product to point to.
            Sql("INSERT INTO dbo.Department (DepartmentName, Budget, EmployeeID) VALUES ('Temp', 0.00, 0)");
            //default value for FK points to department created above.
            AddColumn("dbo.Product", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1));

            //AddColumn("dbo.Product", "DepartmentID", c => c.Int(nullable: false));

            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Product", "DepartmentID");
            AddForeignKey("dbo.Product", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "Manager_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "Department_DepartmentID1", "dbo.Department");
            DropForeignKey("dbo.Employee", "Department_DepartmentID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DepartmentID1" });
            DropIndex("dbo.Employee", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Department", new[] { "Manager_EmployeeID" });
            DropIndex("dbo.Product", new[] { "DepartmentID" });
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            DropColumn("dbo.Product", "DepartmentID");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
