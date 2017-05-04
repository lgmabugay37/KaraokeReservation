namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCodeOnArtists : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Artists", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Code", c => c.String());
        }
    }
}
