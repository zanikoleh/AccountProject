using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class some : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 35),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 100),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.Username)
                .Index(t => t.Username);
            
            /*CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });*/
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Username", "dbo.BankAccounts");
            DropIndex("dbo.Transactions", new[] { "Username" });
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Transactions");
            DropTable("dbo.BankAccounts");
        }
    }
}
