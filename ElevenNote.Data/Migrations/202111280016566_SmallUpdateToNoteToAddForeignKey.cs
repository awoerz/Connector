namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallUpdateToNoteToAddForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "CutsomerAccountId", c => c.Int());
            CreateIndex("dbo.Note", "CutsomerAccountId");
            AddForeignKey("dbo.Note", "CutsomerAccountId", "dbo.CustomerAccount", "CustomerAccountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "CutsomerAccountId", "dbo.CustomerAccount");
            DropIndex("dbo.Note", new[] { "CutsomerAccountId" });
            DropColumn("dbo.Note", "CutsomerAccountId");
        }
    }
}
