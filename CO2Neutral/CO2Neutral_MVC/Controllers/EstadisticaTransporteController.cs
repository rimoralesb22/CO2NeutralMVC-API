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
    public class EstadisticaTransporteController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/EstadisticaTransporte
        public IEnumerable<EstadisticaTransporte> GetEstadisticaTransportes()
        {
            //return db.EstadisticaTransporte.AsEnumerable();
            return db.EstadisticaTransporte.Select(l => new
            {
                idMedios = l.idMedios,
                idCalculadora = l.idCalculadora,
                idFrecuencias = l.idFrecuencias,
                kilometraje = l.kilometraje,
                cantidadVeces = l.cantidadVeces
            }).ToList().Select(x => new EstadisticaTransporte
            {
                idMedios = x.idMedios,
                idCalculadora = x.idCalculadora,
                idFrecuencias = x.idFrecuencias,
                kilometraje = x.kilometraje,
                cantidadVeces = x.cantidadVeces
            });
        }

        // GET api/EstadisticaTransporte/5
        public EstadisticaTransporte GetEstadisticaTransporte(int id)
        {
            EstadisticaTransporte estadisticatransporte = db.EstadisticaTransporte.Find(id);
            if (estadisticatransporte == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return estadisticatransporte;
        }

        // PUT api/EstadisticaTransporte/5
        public HttpResponseMessage PutEstadisticaTransporte(int id, EstadisticaTransporte estadisticatransporte)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != estadisticatransporte.idMedios)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(estadisticatransporte).State = EntityState.Modified;

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

        // POST api/EstadisticaTransporte
        public HttpResponseMessage PostEstadisticaTransporte(EstadisticaTransporte estadisticatransporte)
        {
            if (ModelState.IsValid)
            {
                db.EstadisticaTransporte.Add(estadisticatransporte);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, estadisticatransporte);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = estadisticatransporte.idMedios }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/EstadisticaTransporte/5
        public HttpResponseMessage DeleteEstadisticaTransporte(int id)
        {
            EstadisticaTransporte estadisticatransporte = db.EstadisticaTransporte.Find(id);
            if (estadisticatransporte == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.EstadisticaTransporte.Remove(estadisticatransporte);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, estadisticatransporte);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}