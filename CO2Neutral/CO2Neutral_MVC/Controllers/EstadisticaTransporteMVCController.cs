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
    public class EstadisticaTransporteMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /EstadisticaTransporteMVC/

        public ActionResult Index()
        {
            return View(db.EstadisticaTransporte.ToList());
        }

        //
        // GET: /EstadisticaTransporteMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            EstadisticaTransporte estadisticatransporte = db.EstadisticaTransporte.Find(id);
            if (estadisticatransporte == null)
            {
                return HttpNotFound();
            }
            return View(estadisticatransporte);
        }

        //
        // GET: /EstadisticaTransporteMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EstadisticaTransporteMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadisticaTransporte estadisticatransporte)
        {
            if (ModelState.IsValid)
            {
                db.EstadisticaTransporte.Add(estadisticatransporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadisticatransporte);
        }

        //
        // GET: /EstadisticaTransporteMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EstadisticaTransporte estadisticatransporte = db.EstadisticaTransporte.Find(id);
            if (estadisticatransporte == null)
            {
                return HttpNotFound();
            }
            return View(estadisticatransporte);
        }

        //
        // POST: /EstadisticaTransporteMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstadisticaTransporte estadisticatransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadisticatransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadisticatransporte);
        }

        //
        // GET: /EstadisticaTransporteMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EstadisticaTransporte estadisticatransporte = db.EstadisticaTransporte.Find(id);
            if (estadisticatransporte == null)
            {
                return HttpNotFound();
            }
            return View(estadisticatransporte);
        }

        //
        // POST: /EstadisticaTransporteMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadisticaTransporte estadisticatransporte = db.EstadisticaTransporte.Find(id);
            db.EstadisticaTransporte.Remove(estadisticatransporte);
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