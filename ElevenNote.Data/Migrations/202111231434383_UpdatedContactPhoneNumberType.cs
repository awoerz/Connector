namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedContactPhoneNumberType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contact", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contact", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
