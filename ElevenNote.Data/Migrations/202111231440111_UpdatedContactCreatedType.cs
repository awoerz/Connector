namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedContactCreatedType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "Created", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Contact", "LastContacted", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "LastContacted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "Created", c => c.DateTime(nullable: false));
        }
    }
}
