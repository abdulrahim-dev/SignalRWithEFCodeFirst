namespace SignalRPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMessageType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Message", c => c.Int(nullable: false));
        }
    }
}
