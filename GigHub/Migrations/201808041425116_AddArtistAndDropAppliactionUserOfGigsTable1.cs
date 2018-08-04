namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArtistAndDropAppliactionUserOfGigsTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Gigs", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "ApplicationUser_Id");
            AddForeignKey("dbo.Gigs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
