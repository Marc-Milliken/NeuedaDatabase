namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyforimagetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "EmployeeID_EmployeeID", c => c.Guid());
            CreateIndex("dbo.Images", "EmployeeID_EmployeeID");
            AddForeignKey("dbo.Images", "EmployeeID_EmployeeID", "dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "EmployeeID_EmployeeID", "dbo.Employees");
            DropIndex("dbo.Images", new[] { "EmployeeID_EmployeeID" });
            DropColumn("dbo.Images", "EmployeeID_EmployeeID");
        }
    }
}
