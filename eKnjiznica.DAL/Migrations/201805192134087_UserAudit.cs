namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAudit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAudits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAudits", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserAudits", new[] { "UserId" });
            DropTable("dbo.UserAudits");
        }
    }
}
