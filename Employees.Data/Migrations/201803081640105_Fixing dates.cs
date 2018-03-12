namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixingdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "StartDate", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "DateOfBirth", c => c.String(nullable: false));
        }
    }
}
