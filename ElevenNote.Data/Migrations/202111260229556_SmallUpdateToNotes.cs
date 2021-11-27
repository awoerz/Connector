namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallUpdateToNotes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Note", "Updated", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Note", "Updated", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
