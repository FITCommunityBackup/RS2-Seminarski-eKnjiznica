namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionEmailSentFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "IsEmailSent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "IsEmailSent");
        }
    }
}
