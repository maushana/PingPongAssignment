using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PingPong.Data;
using PingPong.Models.PingPong;

namespace PingPong.Controllers
{
    public class PingPongPlayersController : Controller
    {
        private PingPongContext db = new PingPongContext();

        // GET: PingPongPlayers
        public ActionResult Index()
        {
            var pingPongPlayers = db.PingPongPlayers.Include(p => p.SkillLevel);
            return View(pingPongPlayers.ToList());
        }

        // GET: PingPongPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PingPongPlayers pingPongPlayers = db.PingPongPlayers.Find(id);
            if (pingPongPlayers == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillLevel = db.SkillLevels.Find(pingPongPlayers.SkillLevelId).SkillLevel;
            return View(pingPongPlayers);
        }

        // GET: PingPongPlayers/Create
        public ActionResult Create()
        {
            ViewBag.SkillLevelId = new SelectList(db.SkillLevels, "Id", "SkillLevel");
            return View();
        }

        // POST: PingPongPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dt,FirstName,LastName,Age,Email,SkillLevelId")] PingPongPlayers pingPongPlayers)
        {
            if (ModelState.IsValid)
            {
                db.PingPongPlayers.Add(pingPongPlayers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkillLevelId = new SelectList(db.SkillLevels, "Id", "SkillLevel", pingPongPlayers.SkillLevelId);
            return View(pingPongPlayers);
        }

        // GET: PingPongPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PingPongPlayers pingPongPlayers = db.PingPongPlayers.Find(id);
            if (pingPongPlayers == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillLevelId = new SelectList(db.SkillLevels, "Id", "SkillLevel", pingPongPlayers.SkillLevelId);
            return View(pingPongPlayers);
        }

        // POST: PingPongPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dt,FirstName,LastName,Age,Email,SkillLevelId")] PingPongPlayers pingPongPlayers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pingPongPlayers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillLevelId = new SelectList(db.SkillLevels, "Id", "SkillLevel", pingPongPlayers.SkillLevelId);
            return View(pingPongPlayers);
        }

        // GET: PingPongPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PingPongPlayers pingPongPlayers = db.PingPongPlayers.Find(id);
            if (pingPongPlayers == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillLevel = db.SkillLevels.Find(pingPongPlayers.SkillLevelId).SkillLevel;
            return View(pingPongPlayers);
        }

        // POST: PingPongPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PingPongPlayers pingPongPlayers = db.PingPongPlayers.Find(id);
            db.PingPongPlayers.Remove(pingPongPlayers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
