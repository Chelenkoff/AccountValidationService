namespace AccountValidationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        accountId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Iban = c.String(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.accountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
