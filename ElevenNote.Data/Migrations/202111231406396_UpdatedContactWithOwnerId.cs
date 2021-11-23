namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedContactWithOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "OwnerId");
        }
    }
}
