using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CO2Neutral_MVC.Models;

namespace CO2Neutral_MVC.Controllers
{
    public class ProductosController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/Productos
        public IEnumerable<Productos> GetProductos()
        {
            //return db.Productos.AsEnumerable();
            return db.Productos.Select(l => new
            {
                idProducto = l.idProducto,                
                nombre = l.nombre,
                descripcion = l.descripcion
            }).ToList().Select(x => new Productos
            {
                idProducto = x.idProducto,
                nombre = x.nombre,
                descripcion = x.descripcion
            });
        }

        // GET api/Productos/5
        public Productos GetProductos(int id)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return productos;
        }

        // PUT api/Productos/5
        public HttpResponseMessage PutProductos(int id, Productos productos)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != productos.idProducto)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Productos
        public HttpResponseMessage PostProductos(Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productos);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = productos.idProducto }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Productos/5
        public HttpResponseMessage DeleteProductos(int id)
        {
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Productos.Remove(productos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, productos);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}