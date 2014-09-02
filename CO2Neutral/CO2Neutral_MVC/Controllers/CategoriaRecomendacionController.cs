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
    public class CategoriaRecomendacionController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/CategoriaRecomendacion
        public IEnumerable<CategoriaRecomendacion> GetCategoriaRecomendacions()
        {
            //return db.CategoriaRecomendacion.AsEnumerable();
            return db.CategoriaRecomendacion.Select(l => new
            {
                idCategoria = l.idCategoria,
                nombre = l.nombre                
            }).ToList().Select(x => new CategoriaRecomendacion
            {
                idCategoria = x.idCategoria,
                nombre = x.nombre
            });
        }

        // GET api/CategoriaRecomendacion/5
        public CategoriaRecomendacion GetCategoriaRecomendacion(int id)
        {
            CategoriaRecomendacion categoriarecomendacion = db.CategoriaRecomendacion.Find(id);
            if (categoriarecomendacion == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return categoriarecomendacion;
        }

        // PUT api/CategoriaRecomendacion/5
        public HttpResponseMessage PutCategoriaRecomendacion(int id, CategoriaRecomendacion categoriarecomendacion)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != categoriarecomendacion.idCategoria)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(categoriarecomendacion).State = EntityState.Modified;

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

        // POST api/CategoriaRecomendacion
        public HttpResponseMessage PostCategoriaRecomendacion(CategoriaRecomendacion categoriarecomendacion)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaRecomendacion.Add(categoriarecomendacion);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, categoriarecomendacion);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = categoriarecomendacion.idCategoria }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/CategoriaRecomendacion/5
        public HttpResponseMessage DeleteCategoriaRecomendacion(int id)
        {
            CategoriaRecomendacion categoriarecomendacion = db.CategoriaRecomendacion.Find(id);
            if (categoriarecomendacion == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CategoriaRecomendacion.Remove(categoriarecomendacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, categoriarecomendacion);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}