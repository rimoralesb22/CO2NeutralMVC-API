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
    public class CalculadoraMVCController : Controller
    {
        private BD_TestEntities db = new BD_TestEntities();

        //
        // GET: /CalculadoraMVC/

        public ActionResult Index()
        {
            var calculadora = db.Calculadora.Include(c => c.Usuario);
            return View(calculadora.ToList());
        }

        //
        // GET: /CalculadoraMVC/Details/5

        public ActionResult Details(int id = 0)
        {
            Calculadora calculadora = db.Calculadora.Find(id);
            if (calculadora == null)
            {
                return HttpNotFound();
            }
            return View(calculadora);
        }

        //
        // GET: /CalculadoraMVC/Create

        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "contrasenna");
            return View();
        }

        //
        // POST: /CalculadoraMVC/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Calculadora calculadora)
        {
            if (ModelState.IsValid)
            {
                db.Calculadora.Add(calculadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "contrasenna", calculadora.idUsuario);
            return View(calculadora);
        }

        //
        // GET: /CalculadoraMVC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Calculadora calculadora = db.Calculadora.Find(id);
            if (calculadora == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "contrasenna", calculadora.idUsuario);
            return View(calculadora);
        }

        //
        // POST: /CalculadoraMVC/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Calculadora calculadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "contrasenna", calculadora.idUsuario);
            return View(calculadora);
        }

        //
        // GET: /CalculadoraMVC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Calculadora calculadora = db.Calculadora.Find(id);
            if (calculadora == null)
            {
                return HttpNotFound();
            }
            return View(calculadora);
        }

        //
        // POST: /CalculadoraMVC/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calculadora calculadora = db.Calculadora.Find(id);
            db.Calculadora.Remove(calculadora);
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