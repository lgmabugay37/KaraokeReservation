namespace KaraokeReservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tags");
        }
    }
}
