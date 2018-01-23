namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Address = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(nullable: false, maxLength: 128),
                        EmergencyContact = c.String(nullable: false, maxLength: 128),
                        JobRole = c.String(nullable: false, maxLength: 128),
                        StartDate = c.String(nullable: false, maxLength: 128),
                        PreviousJob = c.String(nullable: false, maxLength: 128),
                        Documentation = c.String(nullable: false, maxLength: 128),
                        UsefulLinks = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
