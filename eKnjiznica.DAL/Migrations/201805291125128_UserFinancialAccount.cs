namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFinancialAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFinancialAccounts",
                c => new
                    {
                        UserFinancialAccountId = c.String(nullable: false, maxLength: 128),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserFinancialAccountId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserFinancialAccountId)
                .Index(t => t.UserFinancialAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFinancialAccounts", "UserFinancialAccountId", "dbo.AspNetUsers");
            DropIndex("dbo.UserFinancialAccounts", new[] { "UserFinancialAccountId" });
            DropTable("dbo.UserFinancialAccounts");
        }
    }
}
