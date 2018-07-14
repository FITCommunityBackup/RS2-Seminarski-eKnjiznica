namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookRatings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookRatings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookRatings", "BookId", "dbo.Books");
            DropIndex("dbo.BookRatings", new[] { "UserId" });
            DropIndex("dbo.BookRatings", new[] { "BookId" });
            DropTable("dbo.BookRatings");
        }
    }
}
