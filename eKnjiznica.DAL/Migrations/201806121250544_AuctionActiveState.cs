namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionActiveState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "IsActive");
        }
    }
}
