namespace Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cenaupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Concerts", "price");
        }
    }
}
