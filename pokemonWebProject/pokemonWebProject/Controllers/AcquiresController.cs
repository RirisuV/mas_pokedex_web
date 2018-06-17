using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pokemonWebProject.DAL;
using pokemonWebProject.Models.pokemonModels;

namespace pokemonWebProject.Controllers
{
    public class AcquiresController : Controller
    {
        private IdentityDbContext db = new IdentityDbContext();

        // GET: Acquires
        public ActionResult Index()
        {
            var acquires = db.Acquires.Include(a => a.Pokemon);
            return View(acquires.ToList());
        }

        // GET: Acquires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acquire acquire = db.Acquires.Find(id);
            if (acquire == null)
            {
                return HttpNotFound();
            }
            return View(acquire);
        }

        // GET: Acquires/Create
        public ActionResult Create()
        {
            ViewBag.acquireID = new SelectList(db.Pokemons, "PokemonID", "nickname");
            return View();
        }

        // POST: Acquires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "acquireID,PokemonID")] Acquire acquire)
        {
            if (ModelState.IsValid)
            {
                db.Acquires.Add(acquire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.acquireID = new SelectList(db.Pokemons, "PokemonID", "nickname", acquire.acquireID);
            return View(acquire);
        }

        // GET: Acquires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acquire acquire = db.Acquires.Find(id);
            if (acquire == null)
            {
                return HttpNotFound();
            }
            ViewBag.acquireID = new SelectList(db.Pokemons, "PokemonID", "nickname", acquire.acquireID);
            return View(acquire);
        }

        // POST: Acquires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "acquireID,PokemonID")] Acquire acquire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acquire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.acquireID = new SelectList(db.Pokemons, "PokemonID", "nickname", acquire.acquireID);
            return View(acquire);
        }

        // GET: Acquires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acquire acquire = db.Acquires.Find(id);
            if (acquire == null)
            {
                return HttpNotFound();
            }
            return View(acquire);
        }

        // POST: Acquires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acquire acquire = db.Acquires.Find(id);
            db.Acquires.Remove(acquire);
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
