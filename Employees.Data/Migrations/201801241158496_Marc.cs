namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmergencyContactName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Employees", "EmergencyContactPhoneNumber", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Employees", "Image", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "Documentation", c => c.String(maxLength: 128));
            AlterColumn("dbo.Employees", "UsefulLinks", c => c.String(maxLength: 128));
            DropColumn("dbo.Employees", "EmergencyContact");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmergencyContact", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employees", "UsefulLinks", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employees", "Documentation", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Employees", "Image");
            DropColumn("dbo.Employees", "EmergencyContactPhoneNumber");
            DropColumn("dbo.Employees", "EmergencyContactName");
        }
    }
}
