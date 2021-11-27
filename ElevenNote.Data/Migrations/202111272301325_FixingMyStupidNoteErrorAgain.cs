namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMyStupidNoteErrorAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "Contact_ContactId", "dbo.Contact");
            DropIndex("dbo.Note", new[] { "Contact_ContactId" });
            RenameColumn(table: "dbo.Note", name: "Contact_ContactId", newName: "ContactId");
            AlterColumn("dbo.Note", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "ContactId");
            AddForeignKey("dbo.Note", "ContactId", "dbo.Contact", "ContactId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "ContactId", "dbo.Contact");
            DropIndex("dbo.Note", new[] { "ContactId" });
            AlterColumn("dbo.Note", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.Note", name: "ContactId", newName: "Contact_ContactId");
            CreateIndex("dbo.Note", "Contact_ContactId");
            AddForeignKey("dbo.Note", "Contact_ContactId", "dbo.Contact", "ContactId");
        }
    }
}
