namespace StoreStatsApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Name", c => c.String());
        }
    }
}
