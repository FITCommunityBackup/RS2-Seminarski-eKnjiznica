namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfPurchase = c.DateTime(nullable: false),
                        BookOfferId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.BookOffers", t => t.BookOfferId)
                .Index(t => t.BookOfferId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBooks", "BookOfferId", "dbo.BookOffers");
            DropForeignKey("dbo.UserBooks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserBooks", new[] { "UserId" });
            DropIndex("dbo.UserBooks", new[] { "BookOfferId" });
            DropTable("dbo.UserBooks");
        }
    }
}
