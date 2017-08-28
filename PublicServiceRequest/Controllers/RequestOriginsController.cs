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
    public class RequestOriginsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestOrigins
        [EnableQuery]
        public IQueryable<RequestOrigin> GetRequestOrigins()
        {
            return db.RequestOrigins.OrderBy(x=>x.RequestOriginName);
        }

        // GET: odata/RequestOrigins(5)
        [EnableQuery]
        public SingleResult<RequestOrigin> GetRequestOrigin([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestOrigins.Where(requestOrigin => requestOrigin.RequestOriginID == key));
        }

        // PUT: odata/RequestOrigins(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestOrigin> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestOrigin requestOrigin = await db.RequestOrigins.FindAsync(key);
            if (requestOrigin == null)
            {
                return NotFound();
            }

            patch.Put(requestOrigin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestOriginExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestOrigin);
        }

        // POST: odata/RequestOrigins
        public async Task<IHttpActionResult> Post(RequestOrigin requestOrigin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestOrigins.Add(requestOrigin);
            await db.SaveChangesAsync();

            return Created(requestOrigin);
        }

        // PATCH: odata/RequestOrigins(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestOrigin> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestOrigin requestOrigin = await db.RequestOrigins.FindAsync(key);
            if (requestOrigin == null)
            {
                return NotFound();
            }

            patch.Patch(requestOrigin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestOriginExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestOrigin);
        }

        // DELETE: odata/RequestOrigins(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestOrigin requestOrigin = await db.RequestOrigins.FindAsync(key);
            if (requestOrigin == null)
            {
                return NotFound();
            }

            db.RequestOrigins.Remove(requestOrigin);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestOrigins(5)/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests([FromODataUri] int key)
        {
            return db.RequestOrigins.Where(m => m.RequestOriginID == key).SelectMany(m => m.Requests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestOriginExists(int key)
        {
            return db.RequestOrigins.Count(e => e.RequestOriginID == key) > 0;
        }
    }
}
