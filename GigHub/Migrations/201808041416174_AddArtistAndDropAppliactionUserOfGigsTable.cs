namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArtistAndDropAppliactionUserOfGigsTable : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Gigs DROP CONSTRAINT [FK_dbo.Gigs_dbo.AspNetUsers_ApplicationUser_Id]");
        }
        
        public override void Down()
        {
           
        }
    }
}
