using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using pokemonWebProject.DAL;
using pokemonWebProject.Models.pokemonModels;

namespace pokemonWebProject.Controllers
{
    public class TrainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        // GET: Trainers
        public ActionResult Index()
        {
            var trainers = db.Trainers.Include(t => t.Person);
            return View(trainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Include(p => p.Person).SingleOrDefault(x => x.TrainerID == id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.TrainerID = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerID,CatchedPokemonsAmount,DexCompleteAmount,Allowance,PersonID")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {

                trainer.PersonID = trainer.TrainerID;
                db.Trainers.Add(trainer);

                if (UserManager.GetRoles(trainer.TrainerID) != null)
                { 
                    if (UserManager.GetRoles(trainer.TrainerID).Contains("Leader"))
                    {
                        Leader leader = db.Leaders.Find(trainer.TrainerID);
                        UserManager.RemoveFromRole(leader.LeaderID, "Leader");
                        db.Leaders.Remove(leader);
                    } 
                }

                UserManager.AddToRole(trainer.TrainerID, "Trainer");

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainerID = new SelectList(db.Users, "Id", "FirstName", trainer.TrainerID);
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainerID = new SelectList(db.Users, "Id", "FirstName", trainer.TrainerID);
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerID,CatchedPokemonsAmount,DexCompleteAmount,Allowance,PersonID")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainerID = new SelectList(db.Users, "Id", "FirstName", trainer.TrainerID);
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Trainer trainer = db.Trainers.Include(p => p.Person).SingleOrDefault(x => x.TrainerID == id);

            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            UserManager.RemoveFromRole(trainer.TrainerID, "Trainer");
            db.Trainers.Remove(trainer);

            // Remove all challnges connected
            var challenge = db.Challenges.Where(x => x.CurrentLeaderID == id).ToList();
            foreach (var ch in challenge)
            {
                db.Challenges.Remove(ch);
            }

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

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    }
}
