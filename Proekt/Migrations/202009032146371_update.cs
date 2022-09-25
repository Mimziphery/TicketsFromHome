namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Museums",
                c => new
                    {
                        MusesumId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MusesumId);
            
            CreateTable(
                "dbo.Theatres",
                c => new
                    {
                        TheatreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Play = c.String(),
                        Room = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TheatreId);
            
            CreateTable(
                "dbo.Plays",
                c => new
                    {
                        PlayId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlayId);
            
            CreateTable(
                "dbo.PlayTheatres",
                c => new
                    {
                        Play_PlayId = c.Int(nullable: false),
                        Theatre_TheatreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Play_PlayId, t.Theatre_TheatreId })
                .ForeignKey("dbo.Plays", t => t.Play_PlayId, cascadeDelete: true)
                .ForeignKey("dbo.Theatres", t => t.Theatre_TheatreId, cascadeDelete: true)
                .Index(t => t.Play_PlayId)
                .Index(t => t.Theatre_TheatreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayTheatres", "Theatre_TheatreId", "dbo.Theatres");
            DropForeignKey("dbo.PlayTheatres", "Play_PlayId", "dbo.Plays");
            DropIndex("dbo.PlayTheatres", new[] { "Theatre_TheatreId" });
            DropIndex("dbo.PlayTheatres", new[] { "Play_PlayId" });
            DropTable("dbo.PlayTheatres");
            DropTable("dbo.Plays");
            DropTable("dbo.Theatres");
            DropTable("dbo.Museums");
        }
    }
}
