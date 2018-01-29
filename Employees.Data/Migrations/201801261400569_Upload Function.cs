namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadFunction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Documentation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Documentation", c => c.String(maxLength: 128));
        }
    }
}
