namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateofBirthAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "StartDate", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employees", "DateOfBirth");
        }
    }
}
