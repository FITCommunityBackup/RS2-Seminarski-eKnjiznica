namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyedBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserBooks", "TransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserBooks", "TransactionId");
            AddForeignKey("dbo.UserBooks", "TransactionId", "dbo.Transactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBooks", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.UserBooks", new[] { "TransactionId" });
            DropColumn("dbo.UserBooks", "TransactionId");
        }
    }
}
