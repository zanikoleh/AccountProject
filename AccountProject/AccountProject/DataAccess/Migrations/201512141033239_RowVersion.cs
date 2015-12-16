using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class RowVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankAccounts", "RowVersion");
        }
    }
}