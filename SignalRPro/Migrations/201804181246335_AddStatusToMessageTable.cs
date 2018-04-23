namespace SignalRPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToMessageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Status");
        }
    }
}
