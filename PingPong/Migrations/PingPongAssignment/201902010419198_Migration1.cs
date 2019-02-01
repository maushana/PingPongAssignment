namespace PingPong.Migrations.PingPongAssignment
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PingPongPlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        SkillLevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PingPongSkillLevels", t => t.SkillLevelId, cascadeDelete: true)
                .Index(t => t.SkillLevelId);
            
            CreateTable(
                "dbo.PingPongSkillLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillLevel = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PingPongPlayers", "SkillLevelId", "dbo.PingPongSkillLevels");
            DropIndex("dbo.PingPongPlayers", new[] { "SkillLevelId" });
            DropTable("dbo.PingPongSkillLevels");
            DropTable("dbo.PingPongPlayers");
        }
    }
}
