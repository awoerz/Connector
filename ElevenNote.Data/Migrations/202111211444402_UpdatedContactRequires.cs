namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedContactRequires : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Contact", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "Email", c => c.String());
            AlterColumn("dbo.Contact", "Name", c => c.String());
        }
    }
}
