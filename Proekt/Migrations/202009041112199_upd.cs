namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plays", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plays", "Date");
        }
    }
}
