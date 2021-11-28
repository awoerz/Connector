namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingNoteTypo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Note", name: "CutsomerAccountId", newName: "CustomerAccountId");
            RenameIndex(table: "dbo.Note", name: "IX_CutsomerAccountId", newName: "IX_CustomerAccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Note", name: "IX_CustomerAccountId", newName: "IX_CutsomerAccountId");
            RenameColumn(table: "dbo.Note", name: "CustomerAccountId", newName: "CutsomerAccountId");
        }
    }
}
