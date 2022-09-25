namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upthe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Theatres", "startTime", c => c.String());
            AddColumn("dbo.Theatres", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Theatres", "Duration");
            DropColumn("dbo.Theatres", "startTime");
        }
    }
}
