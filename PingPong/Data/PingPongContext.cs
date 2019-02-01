using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PingPong.Models.PingPong;

namespace PingPong.Data
{
    public class PingPongContext : DbContext, IPingPongPlayerAppContext
    {
        public PingPongContext() : base("DefaultConnection")
        {

        }

        public void MarkAsModified(PingPongPlayers player)
        {
            Entry(player).State = EntityState.Modified;
        }

        //Defind the tables and the models to use to create the table.
        public DbSet<PingPongPlayers> PingPongPlayers { get; set; }
        public DbSet<PingPongSkillLevel> SkillLevels { get; set; }
    }
}