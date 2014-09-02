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
    public class listaFrecuenciasMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /listaFrecuenciasMVC/

        public ActionResult Index()
        {
            return View(db.listaFrecuencias.ToList());
        }

        //
        // GET: /listaFrecuenciasMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            listaFrecuencias listafrecuencias = db.listaFrecuencias.Find(id);
            if (listafrecuencias == null)
            {
                return HttpNotFound();
            }
            return View(listafrecuencias);
        }

        //
        // GET: /listaFrecuenciasMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /listaFrecuenciasMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(listaFrecuencias listafrecuencias)
        {
            if (ModelState.IsValid)
            {
                db.listaFrecuencias.Add(listafrecuencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listafrecuencias);
        }

        //
        // GET: /listaFrecuenciasMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            listaFrecuencias listafrecuencias = db.listaFrecuencias.Find(id);
            if (listafrecuencias == null)
            {
                return HttpNotFound();
            }
            return View(listafrecuencias);
        }

        //
        // POST: /listaFrecuenciasMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(listaFrecuencias listafrecuencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listafrecuencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listafrecuencias);
        }

        //
        // GET: /listaFrecuenciasMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            listaFrecuencias listafrecuencias = db.listaFrecuencias.Find(id);
            if (listafrecuencias == null)
            {
                return HttpNotFound();
            }
            return View(listafrecuencias);
        }

        //
        // POST: /listaFrecuenciasMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listaFrecuencias listafrecuencias = db.listaFrecuencias.Find(id);
            db.listaFrecuencias.Remove(listafrecuencias);
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