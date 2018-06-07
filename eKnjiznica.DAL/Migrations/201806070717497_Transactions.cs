namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviousAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserFinancialAccountId = c.String(nullable: false, maxLength: 128),
                        AdminId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserFinancialAccounts", t => t.UserFinancialAccountId)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminId)
                .Index(t => t.UserFinancialAccountId)
                .Index(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AdminId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "UserFinancialAccountId", "dbo.UserFinancialAccounts");
            DropIndex("dbo.Transactions", new[] { "AdminId" });
            DropIndex("dbo.Transactions", new[] { "UserFinancialAccountId" });
            DropTable("dbo.Transactions");
        }
    }
}
