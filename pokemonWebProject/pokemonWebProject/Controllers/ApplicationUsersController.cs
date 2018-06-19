using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pokemonWebProject.DAL;
using pokemonWebProject.Models;
using Microsoft.AspNet.Identity;
using pokemonWebProject.Models.pokemonModels;
using Microsoft.Owin.Security;

namespace pokemonWebProject.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var applicationUsers = db.Users.Include(a => a.Leader).Include(a => a.Professor).Include(a => a.Trainer);
            return View(applicationUsers.ToList());
        }

        // GET: ApplicationUsers/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Leaders, "LeaderID", "Specialisation", applicationUser.Id);
            ViewBag.Id = new SelectList(db.Professors, "ProfessorID", "Specialisation", applicationUser.Id);
            ViewBag.Id = new SelectList(db.Trainers, "TrainerID", "TrainerID", applicationUser.Id);
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,FirstName,SecondName,DateOfBirth,Money,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Leaders, "LeaderID", "Specialisation", applicationUser.Id);
            ViewBag.Id = new SelectList(db.Professors, "ProfessorID", "Specialisation", applicationUser.Id);
            ViewBag.Id = new SelectList(db.Trainers, "TrainerID", "TrainerID", applicationUser.Id);
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);

            Trainer trainer = db.Trainers.Find(id);
            Leader leader = db.Leaders.Find(id);

            if (trainer != null)
            {
                db.Trainers.Remove(trainer);
            }
            if (leader != null)
            {
                db.Leaders.Remove(leader);
            }

            var challenge = db.Challenges.Where(x => x.CurrentTrainerID == id).ToList();
            foreach (var ch in challenge)
            {
                db.Challenges.Remove(ch);
            }

            int currentUserId = Int32.Parse(User.Identity.GetUserId());

            if (currentUserId == id)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction("Index", "Home");
            }

            db.Users.Remove(applicationUser);
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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}
 