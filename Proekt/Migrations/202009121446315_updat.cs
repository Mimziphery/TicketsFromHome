namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movie = c.String(),
                        StartTime = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Artist = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Concerts");
            DropTable("dbo.Cinemas");
        }
    }
}
