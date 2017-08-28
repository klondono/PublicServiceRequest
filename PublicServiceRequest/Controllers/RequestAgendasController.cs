using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.Http.OData;
using CustomerService_PSR.Models;
using CustomerService_PSR.Utilities;
using System.Web.Http.OData.Query;

 
namespace PublicServiceRequest.Controllers
{
    //[Authorize]
    public class RequestAgendasController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestAgendas
        [EnableQuery]
        public IQueryable<RequestAgenda> GetRequestAgendas(ODataQueryOptions opts)
        {
            IQueryable<RequestAgenda> agendaList = opts.ApplyTo(db.RequestAgendas.AsQueryable()) as IQueryable<RequestAgenda>;
            return agendaList;
        }

        // GET: odata/RequestAgendas(5)
        [EnableQuery]
        public SingleResult<RequestAgenda> GetRequestAgenda([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestAgendas.Where(requestAgenda => requestAgenda.RequestAgendaID == key));
        }
              
        // PUT: odata/RequestAgendas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<RequestAgenda> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestAgenda requestAgenda = db.RequestAgendas.Find(key);
            if (requestAgenda == null)
            {
                return NotFound();
            }

            patch.Put(requestAgenda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestAgendaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestAgenda);
        }

        // POST: odata/RequestAgendas
        public IHttpActionResult Post(RequestAgenda requestAgenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestAgendas.Add(requestAgenda);
            db.SaveChanges();

            return Created(requestAgenda);
        }

        // PATCH: odata/RequestAgendas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<RequestAgenda> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestAgenda requestAgenda = db.RequestAgendas.Find(key);
            if (requestAgenda == null)
            {
                return NotFound();
            }

            patch.Patch(requestAgenda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestAgendaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestAgenda);
        }

        // DELETE: odata/RequestAgendas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            RequestAgenda requestAgenda = db.RequestAgendas.Find(key);
            if (requestAgenda == null)
            {
                return NotFound();
            }

            db.RequestAgendas.Remove(requestAgenda);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestAgendaExists(int key)
        {
            return db.RequestAgendas.Count(e => e.RequestAgendaID == key) > 0;
        }
    }
}
