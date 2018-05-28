namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "FileLocation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "FileLocation", c => c.String(nullable: false));
        }
    }
}
