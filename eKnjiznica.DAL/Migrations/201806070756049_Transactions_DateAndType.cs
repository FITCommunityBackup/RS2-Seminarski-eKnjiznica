namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions_DateAndType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "DateUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "TransactionType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "TransactionType");
            DropColumn("dbo.Transactions", "DateUtc");
        }
    }
}
