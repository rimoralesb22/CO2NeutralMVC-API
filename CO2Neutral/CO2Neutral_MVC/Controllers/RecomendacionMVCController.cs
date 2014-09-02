using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CO2Neutral_MVC.Models;

namespace CO2Neutral_MVC.Controllers
{
    public class RecomendacionMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /RecomendacionMVC/

        public ActionResult Index()
        {
            var recomendacion = db.Recomendacion.Include(r => r.CategoriaRecomendacion);
            return View(recomendacion.ToList());
        }

        //
        // GET: /RecomendacionMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            Recomendacion recomendacion = db.Recomendacion.Find(id);
            if (recomendacion == null)
            {
                return HttpNotFound();
            }
            return View(recomendacion);
        }

        //
        // GET: /RecomendacionMVC/Create

        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.CategoriaRecomendacion, "idCategoria", "nombre");
            return View();
        }

        //
        // POST: /RecomendacionMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recomendacion recomendacion)
        {
            if (ModelState.IsValid)
            {
                db.Recomendacion.Add(recomendacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.CategoriaRecomendacion, "idCategoria", "nombre", recomendacion.idCategoria);
            return View(recomendacion);
        }

        //
        // GET: /RecomendacionMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Recomendacion recomendacion = db.Recomendacion.Find(id);
            if (recomendacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.CategoriaRecomendacion, "idCategoria", "nombre", recomendacion.idCategoria);
            return View(recomendacion);
        }

        //
        // POST: /RecomendacionMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recomendacion recomendacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recomendacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.CategoriaRecomendacion, "idCategoria", "nombre", recomendacion.idCategoria);
            return View(recomendacion);
        }

        //
        // GET: /RecomendacionMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Recomendacion recomendacion = db.Recomendacion.Find(id);
            if (recomendacion == null)
            {
                return HttpNotFound();
            }
            return View(recomendacion);
        }

        //
        // POST: /RecomendacionMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recomendacion recomendacion = db.Recomendacion.Find(id);
            db.Recomendacion.Remove(recomendacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}