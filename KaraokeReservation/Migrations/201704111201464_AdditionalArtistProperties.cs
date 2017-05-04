namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalArtistProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Artists", "UploaderId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "UploaderId");
            DropColumn("dbo.Artists", "DateAdded");
        }
    }
}
