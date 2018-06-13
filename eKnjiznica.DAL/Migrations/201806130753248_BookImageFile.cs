namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookImageFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImageLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImageLocation");
        }
    }
}
