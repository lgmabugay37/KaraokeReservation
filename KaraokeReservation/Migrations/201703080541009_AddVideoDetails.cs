namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Title", c => c.String());
            AddColumn("dbo.Videos", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Description");
            DropColumn("dbo.Videos", "Title");
        }
    }
}
