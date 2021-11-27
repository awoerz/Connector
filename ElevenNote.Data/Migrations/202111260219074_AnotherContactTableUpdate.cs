namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherContactTableUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.NoteId);
            
            AlterColumn("dbo.Contact", "LastContacted", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "LastContacted", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropTable("dbo.Note");
        }
    }
}
