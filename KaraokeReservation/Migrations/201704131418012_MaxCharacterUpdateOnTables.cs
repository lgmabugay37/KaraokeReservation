namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxCharacterUpdateOnTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Videos", "Title", c => c.String(maxLength: 250));
            AlterColumn("dbo.Videos", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "Description", c => c.String());
            AlterColumn("dbo.Videos", "Title", c => c.String());
            AlterColumn("dbo.Artists", "Description", c => c.String());
        }
    }
}
