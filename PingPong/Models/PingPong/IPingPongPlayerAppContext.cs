using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Models.PingPong
{
    public interface IPingPongPlayerAppContext : IDisposable
    {
        DbSet<PingPongPlayers> PingPongPlayers { get; }
        int SaveChanges();
        void MarkAsModified(PingPongPlayers player);
    }
}
