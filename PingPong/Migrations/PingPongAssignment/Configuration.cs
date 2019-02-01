namespace PingPong.Migrations.PingPongAssignment
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PingPong.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<PingPong.Data.PingPongContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\PingPongAssignment";
        }

        protected override void Seed(PingPong.Data.PingPongContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.SkillLevels.AddOrUpdate(s => s.SkillLevel, DummyData.getSkillLevels().ToArray());
            context.SaveChanges();

            context.PingPongPlayers.AddOrUpdate(
                p => new { p.FirstName, p.LastName, p.Age, p.Email, p.SkillLevelId }, DummyData.getPingPongPlayers(context).ToArray());
        }
    }
}
