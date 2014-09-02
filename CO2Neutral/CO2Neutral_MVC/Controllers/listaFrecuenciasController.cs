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
    public class listaFrecuenciasController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/listaFrecuencias
        public IEnumerable<listaFrecuencias> GetlistaFrecuencias()
        {
            //return db.listaFrecuencias.AsEnumerable();
            return db.listaFrecuencias.Select(l => new
                {
                    idFrecuencias = l.idFrecuencias,
                    nombre = l.nombre,
                    valor = l.valor
                }).ToList().Select(x => new listaFrecuencias
                {
                    idFrecuencias = x.idFrecuencias,
                    nombre = x.nombre,
                    valor = x.valor
                });
        }

        // GET api/listaFrecuencias/5
        public listaFrecuencias GetlistaFrecuencias(int id)
        {
            listaFrecuencias listafrecuencias = db.listaFrecuencias.Find(id);
            if (listafrecuencias == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return listafrecuencias;
        }

        // PUT api/listaFrecuencias/5
        public HttpResponseMessage PutlistaFrecuencias(int id, listaFrecuencias listafrecuencias)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != listafrecuencias.idFrecuencias)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(listafrecuencias).State = EntityState.Modified;

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

        // POST api/listaFrecuencias
        public HttpResponseMessage PostlistaFrecuencias(listaFrecuencias listafrecuencias)
        {
            if (ModelState.IsValid)
            {
                db.listaFrecuencias.Add(listafrecuencias);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, listafrecuencias);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = listafrecuencias.idFrecuencias }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/listaFrecuencias/5
        public HttpResponseMessage DeletelistaFrecuencias(int id)
        {
            listaFrecuencias listafrecuencias = db.listaFrecuencias.Find(id);
            if (listafrecuencias == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.listaFrecuencias.Remove(listafrecuencias);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, listafrecuencias);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}