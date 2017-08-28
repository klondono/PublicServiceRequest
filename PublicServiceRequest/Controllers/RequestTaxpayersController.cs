using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CustomerService_PSR.Models;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class RequestTaxpayersController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestTaxpayers
        [EnableQuery]
        public IQueryable<RequestTaxpayer> GetRequestTaxpayers()
        {
            return db.RequestTaxpayers;
        }

        // GET: odata/RequestTaxpayers(5)
        [EnableQuery]
        public SingleResult<RequestTaxpayer> GetRequestTaxpayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestTaxpayers.Where(requestTaxpayer => requestTaxpayer.RequestTaxpayerID == key));
        }

        // PUT: odata/RequestTaxpayers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestTaxpayer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestTaxpayer requestTaxpayer = await db.RequestTaxpayers.FindAsync(key);
            if (requestTaxpayer == null)
            {
                return NotFound();
            }

            patch.Put(requestTaxpayer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestTaxpayerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestTaxpayer);
        }

        // POST: odata/RequestTaxpayers
        public async Task<IHttpActionResult> Post(RequestTaxpayer requestTaxpayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestTaxpayers.Add(requestTaxpayer);
            await db.SaveChangesAsync();

            return Created(requestTaxpayer);
        }

        // PATCH: odata/RequestTaxpayers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestTaxpayer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestTaxpayer requestTaxpayer = await db.RequestTaxpayers.FindAsync(key);
            if (requestTaxpayer == null)
            {
                return NotFound();
            }

            patch.Patch(requestTaxpayer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestTaxpayerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestTaxpayer);
        }

        // DELETE: odata/RequestTaxpayers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestTaxpayer requestTaxpayer = await db.RequestTaxpayers.FindAsync(key);
            if (requestTaxpayer == null)
            {
                return NotFound();
            }

            db.RequestTaxpayers.Remove(requestTaxpayer);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestTaxpayers(5)/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests([FromODataUri] int key)
        {
            return db.RequestTaxpayers.Where(m => m.RequestTaxpayerID == key).SelectMany(m => m.Requests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestTaxpayerExists(int key)
        {
            return db.RequestTaxpayers.Count(e => e.RequestTaxpayerID == key) > 0;
        }
    }
}
