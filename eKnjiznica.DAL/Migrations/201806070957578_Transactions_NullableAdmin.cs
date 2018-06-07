namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions_NullableAdmin : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transactions", new[] { "AdminId" });
            AlterColumn("dbo.Transactions", "AdminId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "AdminId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transactions", new[] { "AdminId" });
            AlterColumn("dbo.Transactions", "AdminId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Transactions", "AdminId");
        }
    }
}
