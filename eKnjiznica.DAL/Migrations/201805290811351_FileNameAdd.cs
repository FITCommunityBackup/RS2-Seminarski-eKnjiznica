namespace eKnjiznica.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileNameAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "FileName");
        }
    }
}
