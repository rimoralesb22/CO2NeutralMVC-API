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
    public class listaMediosMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /listaMediosMVC/

        public ActionResult Index()
        {
            return View(db.listaMedios.ToList());
        }

        //
        // GET: /listaMediosMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            listaMedios listamedios = db.listaMedios.Find(id);
            if (listamedios == null)
            {
                return HttpNotFound();
            }
            return View(listamedios);
        }

        //
        // GET: /listaMediosMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /listaMediosMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(listaMedios listamedios)
        {
            if (ModelState.IsValid)
            {
                db.listaMedios.Add(listamedios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listamedios);
        }

        //
        // GET: /listaMediosMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            listaMedios listamedios = db.listaMedios.Find(id);
            if (listamedios == null)
            {
                return HttpNotFound();
            }
            return View(listamedios);
        }

        //
        // POST: /listaMediosMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(listaMedios listamedios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listamedios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listamedios);
        }

        //
        // GET: /listaMediosMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            listaMedios listamedios = db.listaMedios.Find(id);
            if (listamedios == null)
            {
                return HttpNotFound();
            }
            return View(listamedios);
        }

        //
        // POST: /listaMediosMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            listaMedios listamedios = db.listaMedios.Find(id);
            db.listaMedios.Remove(listamedios);
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