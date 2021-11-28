namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallUpdateToContactAddingCustomerAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAccount",
                c => new
                    {
                        CustomerAccountId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerAccountId);
            
            AddColumn("dbo.Contact", "CustomerAccountId", c => c.Int(nullable: true));
            CreateIndex("dbo.Contact", "CustomerAccountId");
            AddForeignKey("dbo.Contact", "CustomerAccountId", "dbo.CustomerAccount", "CustomerAccountId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "CustomerAccountId", "dbo.CustomerAccount");
            DropIndex("dbo.Contact", new[] { "CustomerAccountId" });
            DropColumn("dbo.Contact", "CustomerAccountId");
            DropTable("dbo.CustomerAccount");
        }
    }
}
