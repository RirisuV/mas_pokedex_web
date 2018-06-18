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
    public class ProfessorsController : Controller
    {
        private IdentityDbContext db = new IdentityDbContext();

        // GET: Professors
        public ActionResult Index()
        {
            var processors = db.Processors.Include(p => p.Person);
            return View(processors.ToList());
        }

        // GET: Professors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Processors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professors/Create
        public ActionResult Create()
        {
            ViewBag.ProfessorID = new SelectList(db.People, "PersonID", "FirstName");
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessorID,Specialisation,HoldedPokemonAmount,Sallary,PersonID")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Processors.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessorID = new SelectList(db.People, "PersonID", "FirstName", professor.ProfessorID);
            return View(professor);
        }

        // GET: Professors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Processors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessorID = new SelectList(db.People, "PersonID", "FirstName", professor.ProfessorID);
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessorID,Specialisation,HoldedPokemonAmount,Sallary,PersonID")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessorID = new SelectList(db.People, "PersonID", "FirstName", professor.ProfessorID);
            return View(professor);
        }

        // GET: Professors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Processors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Processors.Find(id);
            db.Processors.Remove(professor);
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
