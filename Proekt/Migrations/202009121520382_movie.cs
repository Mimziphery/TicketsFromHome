namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCinemas",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Cinema_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Cinema_Id);
            
            AddColumn("dbo.Cinemas", "CinemaName", c => c.String());
            DropColumn("dbo.Cinemas", "Movie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cinemas", "Movie", c => c.String());
            DropForeignKey("dbo.MovieCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.MovieCinemas", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.MovieCinemas", new[] { "Movie_Id" });
            DropColumn("dbo.Cinemas", "CinemaName");
            DropTable("dbo.MovieCinemas");
            DropTable("dbo.Movies");
        }
    }
}
