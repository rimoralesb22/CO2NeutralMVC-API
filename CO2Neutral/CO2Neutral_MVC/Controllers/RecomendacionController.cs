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
    public class RecomendacionController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/Recomendacion
        public IEnumerable<Recomendacion> GetRecomendacions()
        {
            //var recomendacion = db.Recomendacion.Include(r => r.CategoriaRecomendacion);
            //return recomendacion.AsEnumerable();
            return db.Recomendacion.Select(l => new
            {
                idRecomendacion = l.idRecomendacion,
                idCategoria = l.idCategoria,
                nombre = l.nombre,
                descripcion = l.descripcion
            }).ToList().Select(x => new Recomendacion
            {
                idRecomendacion = x.idRecomendacion,
                idCategoria = x.idCategoria,
                nombre = x.nombre,
                descripcion = x.descripcion
            });
        }

        // GET api/Recomendacion/5
        public Recomendacion GetRecomendacion(int id)
        {
            Recomendacion recomendacion = db.Recomendacion.Find(id);
            if (recomendacion == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recomendacion;
        }

        // PUT api/Recomendacion/5
        public HttpResponseMessage PutRecomendacion(int id, Recomendacion recomendacion)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != recomendacion.idRecomendacion)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(recomendacion).State = EntityState.Modified;

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

        // POST api/Recomendacion
        public HttpResponseMessage PostRecomendacion(Recomendacion recomendacion)
        {
            if (ModelState.IsValid)
            {
                db.Recomendacion.Add(recomendacion);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, recomendacion);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = recomendacion.idRecomendacion }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Recomendacion/5
        public HttpResponseMessage DeleteRecomendacion(int id)
        {
            Recomendacion recomendacion = db.Recomendacion.Find(id);
            if (recomendacion == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Recomendacion.Remove(recomendacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, recomendacion);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}