namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieCinemas", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieCinemas", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.MovieCinemas", new[] { "Movie_Id" });
            DropIndex("dbo.MovieCinemas", new[] { "Cinema_Id" });
            AddColumn("dbo.Cinemas", "Name", c => c.String());
            AddColumn("dbo.Cinemas", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Concerts", "Location", c => c.String());
            DropTable("dbo.Movies");
            DropTable("dbo.MovieCinemas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieCinemas",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Cinema_Id });
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Concerts", "Location");
            DropColumn("dbo.Cinemas", "Price");
            DropColumn("dbo.Cinemas", "Name");
            CreateIndex("dbo.MovieCinemas", "Cinema_Id");
            CreateIndex("dbo.MovieCinemas", "Movie_Id");
            AddForeignKey("dbo.MovieCinemas", "Cinema_Id", "dbo.Cinemas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieCinemas", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
