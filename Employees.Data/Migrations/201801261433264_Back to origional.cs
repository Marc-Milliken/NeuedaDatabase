namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Backtoorigional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Documentation", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Documentation");
        }
    }
}
