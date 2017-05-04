namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoViewCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "ViewCount");
        }
    }
}
