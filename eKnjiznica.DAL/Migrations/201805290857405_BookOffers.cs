namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookOffers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        OfferCreatedTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookOffers", "BookId", "dbo.Books");
            DropIndex("dbo.BookOffers", new[] { "BookId" });
            DropTable("dbo.BookOffers");
        }
    }
}
