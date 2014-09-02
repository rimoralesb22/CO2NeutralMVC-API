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
    public class CentroAcopioController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/CentroAcopio
        public IEnumerable<CentroAcopio> GetCentroAcopios()
        {
            //return db.CentroAcopio.AsEnumerable();
             return db.CentroAcopio.Select(l => new
            {
                idCentroAcopio = l.idCentroAcopio,
                nombre = l.nombre,
                Descripcion = l.Descripcion,
                telefono = l.telefono,
                email = l.email,
                latitud = l.latitud,
                longuitud = l.longuitud
            }).ToList().Select(x => new CentroAcopio
            {
                idCentroAcopio = x.idCentroAcopio,
                nombre = x.nombre,
                Descripcion = x.Descripcion,
                telefono = x.telefono,
                email = x.email,
                latitud = x.latitud,
                longuitud = x.longuitud

               
            }); 
        }

        // GET api/CentroAcopio/5
        public CentroAcopio GetCentroAcopio(int id)
        {
            CentroAcopio centroacopio = db.CentroAcopio.Find(id);
            if (centroacopio == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return centroacopio;
        }

        // PUT api/CentroAcopio/5
        public HttpResponseMessage PutCentroAcopio(int id, CentroAcopio centroacopio)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != centroacopio.idCentroAcopio)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(centroacopio).State = EntityState.Modified;

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

        // POST api/CentroAcopio
        public HttpResponseMessage PostCentroAcopio(CentroAcopio centroacopio)
        {
            if (ModelState.IsValid)
            {
                db.CentroAcopio.Add(centroacopio);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, centroacopio);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = centroacopio.idCentroAcopio }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/CentroAcopio/5
        public HttpResponseMessage DeleteCentroAcopio(int id)
        {
            CentroAcopio centroacopio = db.CentroAcopio.Find(id);
            if (centroacopio == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CentroAcopio.Remove(centroacopio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, centroacopio);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}