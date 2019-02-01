namespace PingPong.Migrations.PingPongAssignment
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PingPongPlayers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PingPongPlayers", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PingPongPlayers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.PingPongPlayers", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
