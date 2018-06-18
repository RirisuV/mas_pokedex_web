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
    public class ChallengesController : Controller
    {
        private IdentityDbContext db = new IdentityDbContext();

        // GET: Challenges
        public ActionResult Index()
        {
            var challenges = db.Challenges.Include(c => c.CurrentLeader).Include(c => c.CurrentTrainer);
            return View(challenges.ToList());
        }

        // GET: Challenges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return HttpNotFound();
            }
            return View(challenge);
        }

        // GET: Challenges/Create
        public ActionResult Create()
        {
            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "LeaderID");
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID");
            return View();
        }

        // POST: Challenges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChallengeID,ChallengeDate,Description,Result,AsAccepted,DeclineReasonTopic,DeclineReasonDescription,CurrentLeaderID,CurrentTrainerID")] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                db.Challenges.Add(challenge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "Specialisation", challenge.CurrentLeaderID);
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID", challenge.CurrentTrainerID);
            return View(challenge);
        }

        // GET: Challenges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "Specialisation", challenge.CurrentLeaderID);
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID", challenge.CurrentTrainerID);
            return View(challenge);
        }

        // POST: Challenges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChallengeID,ChallengeDate,Description,Result,AsAccepted,DeclineReasonTopic,DeclineReasonDescription,CurrentLeaderID,CurrentTrainerID")] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(challenge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "Specialisation", challenge.CurrentLeaderID);
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID", challenge.CurrentTrainerID);
            return View(challenge);
        }

        // GET: Challenges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return HttpNotFound();
            }
            return View(challenge);
        }

        // POST: Challenges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Challenge challenge = db.Challenges.Find(id);
            db.Challenges.Remove(challenge);
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

        // ==============================


        // GET: Challenges/CreateByTrainer
        public ActionResult CreateByTrainer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        // POST: Challenges/CreateByLeader
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByLeader([Bind(Include = "ChallengeID,ChallengeDate,Description,Result,AsAccepted,DeclineReasonTopic,DeclineReasonDescription,CurrentLeaderID,CurrentTrainerID")] Challenge challenge)
        {
            if (ModelState.IsValid)
            {



                db.Challenges.Add(challenge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "Specialisation", challenge.CurrentLeaderID);
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID", challenge.CurrentTrainerID);
            return View(challenge);
        }


    }
}
