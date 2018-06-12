namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auctions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.AuctionBids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AuctionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AuctionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionBids", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Auctions", "BookId", "dbo.Books");
            DropForeignKey("dbo.AuctionBids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.AuctionBids", new[] { "AuctionId" });
            DropIndex("dbo.AuctionBids", new[] { "UserId" });
            DropIndex("dbo.Auctions", new[] { "BookId" });
            DropTable("dbo.AuctionBids");
            DropTable("dbo.Auctions");
        }
    }
}
