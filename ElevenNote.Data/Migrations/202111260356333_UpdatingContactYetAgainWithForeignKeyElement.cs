namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingContactYetAgainWithForeignKeyElement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "Note_NoteId", c => c.Int());
            CreateIndex("dbo.Contact", "Note_NoteId");
            AddForeignKey("dbo.Contact", "Note_NoteId", "dbo.Note", "NoteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "Note_NoteId", "dbo.Note");
            DropIndex("dbo.Contact", new[] { "Note_NoteId" });
            DropColumn("dbo.Contact", "Note_NoteId");
        }
    }
}
