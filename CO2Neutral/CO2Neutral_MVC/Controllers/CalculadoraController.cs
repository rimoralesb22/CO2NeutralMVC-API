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
    public class CalculadoraController : ApiController
    {
        private BD_TestEntities db = new BD_TestEntities();

        // GET api/Calculadora
        public IEnumerable<Calculadora> GetCalculadoras()
        {
            //var calculadora = db.Calculadora.Include(c => c.Usuario);
            //return calculadora.AsEnumerable();
            return db.Calculadora.Select(l => new
            {
                idUsuario = l.idUsuario,
                idCalculdora = l.idCalculdora,
                resultadoTransporte = l.resultadoTransporte,
                resultadoElectricidad = l.resultadoElectricidad,
                resultadoReciclaje = l.resultadoReciclaje,
                resultadoGas = l.resultadoGas
            }).ToList().Select(x => new Calculadora
            {
                idUsuario = x.idUsuario,
                idCalculdora = x.idCalculdora,
                resultadoTransporte = x.resultadoTransporte,
                resultadoElectricidad = x.resultadoElectricidad,
                resultadoReciclaje = x.resultadoReciclaje,
                resultadoGas = x.resultadoGas
            });
        }

        // GET api/Calculadora/5
        public Calculadora GetCalculadora(int id)
        {
            Calculadora calculadora = db.Calculadora.Find(id);
            if (calculadora == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return calculadora;
        }

        // PUT api/Calculadora/5
        public HttpResponseMessage PutCalculadora(int id, Calculadora calculadora)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != calculadora.idCalculdora)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(calculadora).State = EntityState.Modified;

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

        // POST api/Calculadora
        public HttpResponseMessage PostCalculadora(Calculadora calculadora)
        {
            if (ModelState.IsValid)
            {
                db.Calculadora.Add(calculadora);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, calculadora);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = calculadora.idCalculdora }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Calculadora/5
        public HttpResponseMessage DeleteCalculadora(int id)
        {
            Calculadora calculadora = db.Calculadora.Find(id);
            if (calculadora == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Calculadora.Remove(calculadora);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, calculadora);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}