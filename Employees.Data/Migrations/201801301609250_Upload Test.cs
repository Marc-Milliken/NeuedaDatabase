namespace Employees.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Content", c => c.Binary(maxLength: 128));
            AlterColumn("dbo.Documents", "Name", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Documents", "Content");
        }
    }
}
