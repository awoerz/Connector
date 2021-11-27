namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryingToAddNotesToContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contact", "Note_NoteId", "dbo.Note");
            DropIndex("dbo.Contact", new[] { "Note_NoteId" });
            AddColumn("dbo.Note", "Contact_ContactId", c => c.Int());
            CreateIndex("dbo.Note", "Contact_ContactId");
            AddForeignKey("dbo.Note", "Contact_ContactId", "dbo.Contact", "ContactId");
            DropColumn("dbo.Contact", "Note_NoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "Note_NoteId", c => c.Int());
            DropForeignKey("dbo.Note", "Contact_ContactId", "dbo.Contact");
            DropIndex("dbo.Note", new[] { "Contact_ContactId" });
            DropColumn("dbo.Note", "Contact_ContactId");
            CreateIndex("dbo.Contact", "Note_NoteId");
            AddForeignKey("dbo.Contact", "Note_NoteId", "dbo.Note", "NoteId");
        }
    }
}
