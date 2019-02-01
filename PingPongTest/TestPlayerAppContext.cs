using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.Models.PingPong;

namespace PingPongTest
{
    public class TestPlayerAppContext : IPingPongPlayerAppContext
    {
        public TestPlayerAppContext()
        {
            this.PingPongPlayers = new TestPlayerDbSet();
        }

        public DbSet<PingPongPlayers> PingPongPlayers { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(PingPongPlayers player) { }
        public void Dispose() { }
    }
}
