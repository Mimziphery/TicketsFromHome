namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plays", "Theatre_TheatreId", "dbo.Theatres");
            DropIndex("dbo.Plays", new[] { "Theatre_TheatreId" });
            AddColumn("dbo.Theatres", "playDate", c => c.String());
            DropTable("dbo.Plays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Plays",
                c => new
                    {
                        PlayId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        startTime = c.String(),
                        Date = c.String(),
                        Duration = c.String(),
                        Theatre_TheatreId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayId);
            
            DropColumn("dbo.Theatres", "playDate");
            CreateIndex("dbo.Plays", "Theatre_TheatreId");
            AddForeignKey("dbo.Plays", "Theatre_TheatreId", "dbo.Theatres", "TheatreId");
        }
    }
}
