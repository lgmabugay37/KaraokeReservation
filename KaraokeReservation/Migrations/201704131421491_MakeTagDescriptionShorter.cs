namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTagDescriptionShorter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Description", c => c.String());
        }
    }
}
