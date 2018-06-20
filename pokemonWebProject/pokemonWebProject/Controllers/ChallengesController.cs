 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using pokemonWebProject.DAL;
using pokemonWebProject.Models.pokemonModels;

namespace pokemonWebProject.Controllers
{
    public class ChallengesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Challenges
        public ActionResult Index()
        {
            int parsedId = int.Parse(User.Identity.GetUserId());
            int currentUserId = db.Users.FirstOrDefault(x => x.Id == parsedId).Id;
            var challenges = db.Challenges.Include(c => c.CurrentLeader.Person).Include(c => c.CurrentTrainer.Person).ToList().Where(c => c.CurrentLeaderID == currentUserId);
            return View(challenges);
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

        // GET: Challenges/CreateByTrainer/5
        [Authorize(Roles = "Trainer")]
        public ActionResult CreateByTrainer(int id)
        {
            Challenge challenge = new Challenge();
            challenge.CurrentLeaderID = id;

            return View(challenge);

        }

        // POST: Challenges/CreateByLeader
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainer")]
        public ActionResult CreateByTrainer([Bind(Include = "ChallengeID,ChallengeDate,Description,Result,AsAccepted,DeclineReasonTopic,DeclineReasonDescription,CurrentLeaderID,CurrentTrainerID")] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                Challenge result = new Challenge
                {
                    ChallengeID = challenge.ChallengeID,
                    ChallengeDate = challenge.ChallengeDate,
                    CurrentTrainerID = getCurrentUser(),
                    CurrentLeaderID = challenge.CurrentLeaderID
                };

                db.Challenges.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "Specialisation", challenge.CurrentLeaderID);
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID", challenge.CurrentTrainerID);
            return View(challenge);
        }

        // GET: Challenges/Accept/5
        [Authorize(Roles = "Leader")]
        public ActionResult Accept(int? id)
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

        // POST: Challenges/Accept/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Leader")]
        public ActionResult Accept([Bind(Include = "ChallengeID,ChallengeDate,Description,Result,AsAccepted,DeclineReasonTopic,DeclineReasonDescription,CurrentLeaderID,CurrentTrainerID")] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                var result = new Challenge
                {
                    ChallengeID = challenge.ChallengeID,
                    ChallengeDate = challenge.ChallengeDate,
                    Result = challenge.Result,
                    Description = challenge.Description,
                    AsAccepted = true,
                    CurrentLeaderID = challenge.CurrentLeaderID,
                    CurrentTrainerID = challenge.CurrentTrainerID
                };

                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();

                sendAcceptInfoEmail(challenge.CurrentTrainerID);

                return RedirectToAction("Index");
            }

            ViewBag.CurrentLeaderID = new SelectList(db.Leaders, "LeaderID", "Specialisation", challenge.CurrentLeaderID);
            ViewBag.CurrentTrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerID", challenge.CurrentTrainerID);
            return View(challenge);
        }

        // GET: Challenges/Decline/5
        [Authorize(Roles = "Leader")]
        public ActionResult Decline(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Leader")]
        public ActionResult Decline([Bind(Include = "ChallengeID,ChallengeDate,Description,Result,AsAccepted,DeclineReasonTopic,DeclineReasonDescription,CurrentLeaderID,CurrentTrainerID")] Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                var result = new Challenge
                {
                    ChallengeID = challenge.ChallengeID,
                    ChallengeDate = challenge.ChallengeDate,
                    DeclineReasonTopic = challenge.DeclineReasonTopic,
                    DeclineReasonDescription = challenge.DeclineReasonDescription,
                    AsAccepted = false,
                    CurrentLeaderID = challenge.CurrentLeaderID,
                    CurrentTrainerID = challenge.CurrentTrainerID
                };

                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();

                sendDeclineInfoEmail(challenge.CurrentTrainerID);

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

        public int getCurrentUser()
        {
            int currentUserId = int.Parse(User.Identity.GetUserId());
            var currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            return currentUser.Id;
        }

        private readonly static string mailClient = "yourmail_ @gmail.com";

        public void sendAcceptInfoEmail(int trainerID)
        {
            var trainer = db.Trainers.Include(x => x.Person).SingleOrDefault(x => x.TrainerID == trainerID).Person;
            var email = trainer.Email;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("mas.projekt.api2@gmail.com", "Pjatk1234!");
            smtp.Send(mailClient, email, "Akceptacja pojedynku!", "Pojedynek odbędzie się... blablabla...");
        }

        public void sendDeclineInfoEmail(int trainerID)
        {
            var trainer = db.Trainers.Include(x => x.Person).SingleOrDefault(x => x.TrainerID == trainerID).Person;
            var email = trainer.Email;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("mas.projekt.api2@gmail.com", "Pjatk1234!");
            smtp.Send(mailClient, email, "Odrzucenie pojedynku!", "Pojedynek nie odbędzie się z powodu... blablabla...");
        }

    }
}
