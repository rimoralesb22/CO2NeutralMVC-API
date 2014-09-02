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
    public class ProductosMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /ProductosMVC/

        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        //
        // GET: /ProductosMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        //
        // GET: /ProductosMVC/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductosMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

        //
        // GET: /ProductosMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        //
        // POST: /ProductosMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        //
        // GET: /ProductosMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        //
        // POST: /ProductosMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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