namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationAddThumbnailContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "ThumbnailContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "ThumbnailContent");
        }
    }
}
