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
    public class listaMediosController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/listaMedios
        public IEnumerable<listaMedios> GetlistaMedios()
        {
            //return db.listaMedios.AsEnumerable();
            return db.listaMedios.Select(l => new
            {
                idMedios = l.idMedios,
                nombre = l.nombre,
                valor = l.valor
            }).ToList().Select(x => new listaMedios
            {
                idMedios = x.idMedios,
                nombre = x.nombre,
                valor = x.valor
            });
        }

        // GET api/listaMedios/5
        public listaMedios GetlistaMedios(int id)
        {
            listaMedios listamedios = db.listaMedios.Find(id);
            if (listamedios == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return listamedios;
        }

        // PUT api/listaMedios/5
        public HttpResponseMessage PutlistaMedios(int id, listaMedios listamedios)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != listamedios.idMedios)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(listamedios).State = EntityState.Modified;

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

        // POST api/listaMedios
        public HttpResponseMessage PostlistaMedios(listaMedios listamedios)
        {
            if (ModelState.IsValid)
            {
                db.listaMedios.Add(listamedios);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, listamedios);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = listamedios.idMedios }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/listaMedios/5
        public HttpResponseMessage DeletelistaMedios(int id)
        {
            listaMedios listamedios = db.listaMedios.Find(id);
            if (listamedios == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.listaMedios.Remove(listamedios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, listamedios);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}