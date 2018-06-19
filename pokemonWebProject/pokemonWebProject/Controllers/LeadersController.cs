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
    public class LeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        // GET: Leaders
        [Authorize(Roles = "Admin, Trainer")]
        
        public ActionResult Index()
        {
            var leaders = db.Leaders.Include(l => l.Person);
            return View(leaders.ToList());
        }

        // GET: Leaders/Details/5
        [Authorize(Roles = "Admin, Trainer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Leader leader = db.Leaders.Include(p => p.Person).SingleOrDefault(x => x.LeaderID == id);
           
            if (leader == null)
            {
                return HttpNotFound();
            }
            return View(leader);
        }

        // GET: Leaders/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.LeaderID = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Leaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "LeaderID,Specialisation,SecondJob,Sallary,PersonID")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                db.Leaders.Add(leader);

                if (UserManager.GetRoles(leader.LeaderID) != null)
                {
                    if (UserManager.GetRoles(leader.LeaderID).Contains("Trainer"))
                    {
                        Trainer trainer = db.Trainers.Find(leader.LeaderID);
                        UserManager.RemoveFromRole(trainer.TrainerID, "Trainer");
                        db.Trainers.Remove(trainer);

                        var challenge = db.Challenges.Where(x => x.CurrentTrainerID == leader.LeaderID).ToList();
                        foreach (var ch in challenge)
                        {
                            db.Challenges.Remove(ch);
                        }
                    }
                }

                UserManager.AddToRole(leader.LeaderID, "Leader");

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeaderID = new SelectList(db.Users, "Id", "FirstName", leader.LeaderID);
            return View(leader);
        }

        // GET: Leaders/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leader leader = db.Leaders.Find(id);
            if (leader == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeaderID = new SelectList(db.Users, "Id", "FirstName", leader.LeaderID);
            return View(leader);
        }

        // POST: Leaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "LeaderID,Specialisation,SecondJob,Sallary,PersonID")] Leader leader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeaderID = new SelectList(db.Users, "Id", "FirstName", leader.LeaderID);
            return View(leader);
        }

        // GET: Leaders/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leader leader = db.Leaders.Include(p => p.Person).SingleOrDefault(x => x.LeaderID == id);

            if (leader == null)
            {
                return HttpNotFound();
            }
            return View(leader);
        }

        // POST: Leaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Leader leader = db.Leaders.Find(id);
            UserManager.RemoveFromRole(leader.LeaderID, "Leader");
            db.Leaders.Remove(leader);

            // Remove all challnges connected
            var challenge = db.Challenges.Where(x => x.CurrentTrainerID == id).ToList();
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
