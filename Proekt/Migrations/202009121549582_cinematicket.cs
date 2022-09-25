namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cinematicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Price");
        }
    }
}
