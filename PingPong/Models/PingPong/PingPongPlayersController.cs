using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PingPong.Data;

namespace PingPong.Models.PingPong
{
    public class PingPongPlayersController : ApiController
    {
        private IPingPongPlayerAppContext db = new PingPongContext();

        public PingPongPlayersController() { }

        public PingPongPlayersController(IPingPongPlayerAppContext context)
        {
            db = context;
        }

        // GET: api/PingPongPlayers
        public IQueryable<PingPongPlayers> GetPingPongPlayers()
        {
            return db.PingPongPlayers;
        }

        // GET: api/PingPongPlayers/5
        [ResponseType(typeof(PingPongPlayers))]
        public IHttpActionResult GetPingPongPlayers(int id)
        {
            PingPongPlayers pingPongPlayers = db.PingPongPlayers.Find(id);
            if (pingPongPlayers == null)
            {
                return NotFound();
            }

            return Ok(pingPongPlayers);
        }

        // PUT: api/PingPongPlayers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPingPongPlayers(int id, PingPongPlayers pingPongPlayers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pingPongPlayers.Id)
            {
                return BadRequest();
            }

            //db.Entry(pingPongPlayers).State = EntityState.Modified;
            db.MarkAsModified(pingPongPlayers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PingPongPlayersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PingPongPlayers
        [ResponseType(typeof(PingPongPlayers))]
        public IHttpActionResult PostPingPongPlayers(PingPongPlayers pingPongPlayers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PingPongPlayers.Add(pingPongPlayers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pingPongPlayers.Id }, pingPongPlayers);
        }

        // DELETE: api/PingPongPlayers/5
        [ResponseType(typeof(PingPongPlayers))]
        public IHttpActionResult DeletePingPongPlayers(int id)
        {
            PingPongPlayers pingPongPlayers = db.PingPongPlayers.Find(id);
            if (pingPongPlayers == null)
            {
                return NotFound();
            }

            db.PingPongPlayers.Remove(pingPongPlayers);
            db.SaveChanges();

            return Ok(pingPongPlayers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PingPongPlayersExists(int id)
        {
            return db.PingPongPlayers.Count(e => e.Id == id) > 0;
        }
    }
}