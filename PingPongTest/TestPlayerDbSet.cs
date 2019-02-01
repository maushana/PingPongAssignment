using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.Models.PingPong;

namespace PingPongTest
{
    class TestPlayerDbSet : TestDbSet<PingPongPlayers>
    {
        public override PingPongPlayers Find(params object[] keyValues)
        {
            return this.SingleOrDefault(player => player.Id == (int)keyValues.Single());
        }
    }
}
