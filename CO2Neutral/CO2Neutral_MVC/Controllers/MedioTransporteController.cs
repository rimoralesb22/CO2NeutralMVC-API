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
    public class MedioTransporteController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/MedioTransporte
        public IEnumerable<MedioTransporte> GetMedioTransportes()
        {
            //var mediotransporte = db.MedioTransporte.Include(m => m.Calculadora).Include(m => m.listaFrecuencias).Include(m => m.listaMedios);
            //return mediotransporte.AsEnumerable();
             return db.MedioTransporte.Select(l => new
            {
                idCalculdora = l.idCalculdora,
                idFrecuencias = l.idFrecuencias,
                idMedios = l.idMedios,
                kilometraje = l.kilometraje,
                cantidadVeces = l.cantidadVeces
            }).ToList().Select(x => new MedioTransporte
            {
                idCalculdora = x.idCalculdora,
                idFrecuencias = x.idFrecuencias,
                idMedios = x.idMedios,
                kilometraje = x.kilometraje,
                cantidadVeces = x.cantidadVeces
            });
        
        }

        // GET api/MedioTransporte/5
        public MedioTransporte GetMedioTransporte(int id)
        {
            MedioTransporte mediotransporte = db.MedioTransporte.Find(id);
            if (mediotransporte == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return mediotransporte;
        }

        // PUT api/MedioTransporte/5
        public HttpResponseMessage PutMedioTransporte(int id, MedioTransporte mediotransporte)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != mediotransporte.idCalculdora)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(mediotransporte).State = EntityState.Modified;

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

        // POST api/MedioTransporte
        public HttpResponseMessage PostMedioTransporte(MedioTransporte mediotransporte)
        {
            if (ModelState.IsValid)
            {
                db.MedioTransporte.Add(mediotransporte);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mediotransporte);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mediotransporte.idCalculdora }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/MedioTransporte/5
        public HttpResponseMessage DeleteMedioTransporte(int id)
        {
            MedioTransporte mediotransporte = db.MedioTransporte.Find(id);
            if (mediotransporte == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.MedioTransporte.Remove(mediotransporte);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, mediotransporte);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}