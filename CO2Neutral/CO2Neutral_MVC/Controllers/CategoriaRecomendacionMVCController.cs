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
    public class CategoriaRecomendacionMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /CategoriaRecomendacionMVC/

        public ActionResult Index()
        {
            return View(db.CategoriaRecomendacion.ToList());
        }

        //
        // GET: /CategoriaRecomendacionMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            CategoriaRecomendacion categoriarecomendacion = db.CategoriaRecomendacion.Find(id);
            if (categoriarecomendacion == null)
            {
                return HttpNotFound();
            }
            return View(categoriarecomendacion);
        }

        //
        // GET: /CategoriaRecomendacionMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoriaRecomendacionMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaRecomendacion categoriarecomendacion)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaRecomendacion.Add(categoriarecomendacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriarecomendacion);
        }

        //
        // GET: /CategoriaRecomendacionMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CategoriaRecomendacion categoriarecomendacion = db.CategoriaRecomendacion.Find(id);
            if (categoriarecomendacion == null)
            {
                return HttpNotFound();
            }
            return View(categoriarecomendacion);
        }

        //
        // POST: /CategoriaRecomendacionMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaRecomendacion categoriarecomendacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriarecomendacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriarecomendacion);
        }

        //
        // GET: /CategoriaRecomendacionMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CategoriaRecomendacion categoriarecomendacion = db.CategoriaRecomendacion.Find(id);
            if (categoriarecomendacion == null)
            {
                return HttpNotFound();
            }
            return View(categoriarecomendacion);
        }

        //
        // POST: /CategoriaRecomendacionMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaRecomendacion categoriarecomendacion = db.CategoriaRecomendacion.Find(id);
            db.CategoriaRecomendacion.Remove(categoriarecomendacion);
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