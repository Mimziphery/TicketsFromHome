namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cinemas", "CinemaName", c => c.String(nullable: false));
            AlterColumn("dbo.Cinemas", "StartTime", c => c.String(nullable: false));
            AlterColumn("dbo.Cinemas", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Cinemas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Concerts", "Artist", c => c.String(nullable: false));
            AlterColumn("dbo.Concerts", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Concerts", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Museums", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Museums", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Museums", "WorkTime", c => c.String(nullable: false));
            AlterColumn("dbo.Theatres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Theatres", "Play", c => c.String(nullable: false));
            AlterColumn("dbo.Theatres", "playDate", c => c.String(nullable: false));
            AlterColumn("dbo.Theatres", "startTime", c => c.String(nullable: false));
            AlterColumn("dbo.Theatres", "Duration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Theatres", "Duration", c => c.String());
            AlterColumn("dbo.Theatres", "startTime", c => c.String());
            AlterColumn("dbo.Theatres", "playDate", c => c.String());
            AlterColumn("dbo.Theatres", "Play", c => c.String());
            AlterColumn("dbo.Theatres", "Name", c => c.String());
            AlterColumn("dbo.Museums", "WorkTime", c => c.String());
            AlterColumn("dbo.Museums", "Contact", c => c.String());
            AlterColumn("dbo.Museums", "Name", c => c.String());
            AlterColumn("dbo.Concerts", "Location", c => c.String());
            AlterColumn("dbo.Concerts", "Date", c => c.String());
            AlterColumn("dbo.Concerts", "Artist", c => c.String());
            AlterColumn("dbo.Cinemas", "Name", c => c.String());
            AlterColumn("dbo.Cinemas", "Date", c => c.String());
            AlterColumn("dbo.Cinemas", "StartTime", c => c.String());
            AlterColumn("dbo.Cinemas", "CinemaName", c => c.String());
        }
    }
}
