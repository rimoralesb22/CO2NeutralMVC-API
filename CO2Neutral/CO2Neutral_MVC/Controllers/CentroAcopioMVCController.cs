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
    public class CentroAcopioMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /CentroAcopioMVC/

        public ActionResult Index()
        {
            return View(db.CentroAcopio.ToList());
        }

        //
        // GET: /CentroAcopioMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            CentroAcopio centroacopio = db.CentroAcopio.Find(id);
            if (centroacopio == null)
            {
                return HttpNotFound();
            }
            return View(centroacopio);
        }

        //
        // GET: /CentroAcopioMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CentroAcopioMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CentroAcopio centroacopio)
        {
            if (ModelState.IsValid)
            {
                db.CentroAcopio.Add(centroacopio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroacopio);
        }

        //
        // GET: /CentroAcopioMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CentroAcopio centroacopio = db.CentroAcopio.Find(id);
            if (centroacopio == null)
            {
                return HttpNotFound();
            }
            return View(centroacopio);
        }

        //
        // POST: /CentroAcopioMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CentroAcopio centroacopio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centroacopio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centroacopio);
        }

        //
        // GET: /CentroAcopioMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CentroAcopio centroacopio = db.CentroAcopio.Find(id);
            if (centroacopio == null)
            {
                return HttpNotFound();
            }
            return View(centroacopio);
        }

        //
        // POST: /CentroAcopioMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAcopio centroacopio = db.CentroAcopio.Find(id);
            db.CentroAcopio.Remove(centroacopio);
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