namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyBettwenUserAndGig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropColumn("dbo.Gigs", "Artist_Id");
        }
    }
}
