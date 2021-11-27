namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherFrickenMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "ContactId", "dbo.Contact");
            DropIndex("dbo.Note", new[] { "ContactId" });
            AlterColumn("dbo.Note", "ContactId", c => c.Int());
            CreateIndex("dbo.Note", "ContactId");
            AddForeignKey("dbo.Note", "ContactId", "dbo.Contact", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "ContactId", "dbo.Contact");
            DropIndex("dbo.Note", new[] { "ContactId" });
            AlterColumn("dbo.Note", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "ContactId");
            AddForeignKey("dbo.Note", "ContactId", "dbo.Contact", "ContactId", cascadeDelete: true);
        }
    }
}
