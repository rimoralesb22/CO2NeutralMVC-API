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
    public class MedioTransporteMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /MedioTransporteMVC/

        public ActionResult Index()
        {
            var mediotransporte = db.MedioTransporte.Include(m => m.Calculadora).Include(m => m.listaFrecuencias).Include(m => m.listaMedios);
            return View(mediotransporte.ToList());
        }

        //
        // GET: /MedioTransporteMVC/Details/5

        public ActionResult Details(int idCalculadora, int idMedios)
        {
            MedioTransporte mediotransporte = db.MedioTransporte.Find(idCalculadora,  idMedios);
            if (mediotransporte == null)
            {
                return HttpNotFound();
            }
            return View(mediotransporte);
        }

        //
        // GET: /MedioTransporteMVC/Create

        public ActionResult Create()
        {
            ViewBag.idCalculdora = new SelectList(db.Calculadora, "idCalculdora", "idCalculdora");
            ViewBag.idFrecuencias = new SelectList(db.listaFrecuencias, "idFrecuencias", "nombre");
            ViewBag.idMedios = new SelectList(db.listaMedios, "idMedios", "nombre");
            return View();
        }

        //
        // POST: /MedioTransporteMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedioTransporte mediotransporte)
        {
            if (ModelState.IsValid)
            {
                db.MedioTransporte.Add(mediotransporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCalculdora = new SelectList(db.Calculadora, "idCalculdora", "idCalculdora", mediotransporte.idCalculdora);
            ViewBag.idFrecuencias = new SelectList(db.listaFrecuencias, "idFrecuencias", "nombre", mediotransporte.idFrecuencias);
            ViewBag.idMedios = new SelectList(db.listaMedios, "idMedios", "nombre", mediotransporte.idMedios);
            return View(mediotransporte);
        }

        //
        // GET: /MedioTransporteMVC/Edit/5

        public ActionResult Edit(int idCalculadora, int idMedios)
        {
            MedioTransporte mediotransporte = db.MedioTransporte.Find(idCalculadora, idMedios);
            if (mediotransporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCalculdora = new SelectList(db.Calculadora, "idCalculdora", "idCalculdora", mediotransporte.idCalculdora);
            ViewBag.idFrecuencias = new SelectList(db.listaFrecuencias, "idFrecuencias", "nombre", mediotransporte.idFrecuencias);
            ViewBag.idMedios = new SelectList(db.listaMedios, "idMedios", "nombre", mediotransporte.idMedios);
            return View(mediotransporte);
        }

        //
        // POST: /MedioTransporteMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedioTransporte mediotransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediotransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCalculdora = new SelectList(db.Calculadora, "idCalculdora", "idCalculdora", mediotransporte.idCalculdora);
            ViewBag.idFrecuencias = new SelectList(db.listaFrecuencias, "idFrecuencias", "nombre", mediotransporte.idFrecuencias);
            ViewBag.idMedios = new SelectList(db.listaMedios, "idMedios", "nombre", mediotransporte.idMedios);
            return View(mediotransporte);
        }

        //
        // GET: /MedioTransporteMVC/Delete/5

        public ActionResult Delete(int idCalculadora, int idMedios)
        {
            MedioTransporte mediotransporte = db.MedioTransporte.Find(idCalculadora, idMedios);
            if (mediotransporte == null)
            {
                return HttpNotFound();
            }
            return View(mediotransporte);
        }

        //
        // POST: /MedioTransporteMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idCalculadora, int idMedios)
        {
            MedioTransporte mediotransporte = db.MedioTransporte.Find(idCalculadora, idMedios);
            db.MedioTransporte.Remove(mediotransporte);
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