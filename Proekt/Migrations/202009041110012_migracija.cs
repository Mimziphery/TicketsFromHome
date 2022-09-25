namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlayTheatres", "Play_PlayId", "dbo.Plays");
            DropForeignKey("dbo.PlayTheatres", "Theatre_TheatreId", "dbo.Theatres");
            DropIndex("dbo.PlayTheatres", new[] { "Play_PlayId" });
            DropIndex("dbo.PlayTheatres", new[] { "Theatre_TheatreId" });
            AddColumn("dbo.Museums", "Contact", c => c.String());
            AddColumn("dbo.Museums", "WorkTime", c => c.String());
            AddColumn("dbo.Plays", "startTime", c => c.String());
            AddColumn("dbo.Plays", "Duration", c => c.String());
            AddColumn("dbo.Plays", "Theatre_TheatreId", c => c.Int());
            CreateIndex("dbo.Plays", "Theatre_TheatreId");
            AddForeignKey("dbo.Plays", "Theatre_TheatreId", "dbo.Theatres", "TheatreId");
            DropTable("dbo.PlayTheatres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayTheatres",
                c => new
                    {
                        Play_PlayId = c.Int(nullable: false),
                        Theatre_TheatreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Play_PlayId, t.Theatre_TheatreId });
            
            DropForeignKey("dbo.Plays", "Theatre_TheatreId", "dbo.Theatres");
            DropIndex("dbo.Plays", new[] { "Theatre_TheatreId" });
            DropColumn("dbo.Plays", "Theatre_TheatreId");
            DropColumn("dbo.Plays", "Duration");
            DropColumn("dbo.Plays", "startTime");
            DropColumn("dbo.Museums", "WorkTime");
            DropColumn("dbo.Museums", "Contact");
            CreateIndex("dbo.PlayTheatres", "Theatre_TheatreId");
            CreateIndex("dbo.PlayTheatres", "Play_PlayId");
            AddForeignKey("dbo.PlayTheatres", "Theatre_TheatreId", "dbo.Theatres", "TheatreId", cascadeDelete: true);
            AddForeignKey("dbo.PlayTheatres", "Play_PlayId", "dbo.Plays", "PlayId", cascadeDelete: true);
        }
    }
}
