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
    public class RequestPrioritiesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestPriorities
        [EnableQuery]
        public IQueryable<RequestPriority> GetRequestPriorities()
        {
            return db.RequestPriorities;
        }

        // GET: odata/RequestPriorities(5)
        [EnableQuery]
        public SingleResult<RequestPriority> GetRequestPriority([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestPriorities.Where(requestPriority => requestPriority.RequestPriorityID == key));
        }

        // PUT: odata/RequestPriorities(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestPriority> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestPriority requestPriority = await db.RequestPriorities.FindAsync(key);
            if (requestPriority == null)
            {
                return NotFound();
            }

            patch.Put(requestPriority);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestPriorityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestPriority);
        }

        // POST: odata/RequestPriorities
        public async Task<IHttpActionResult> Post(RequestPriority requestPriority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestPriorities.Add(requestPriority);
            await db.SaveChangesAsync();

            return Created(requestPriority);
        }

        // PATCH: odata/RequestPriorities(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestPriority> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestPriority requestPriority = await db.RequestPriorities.FindAsync(key);
            if (requestPriority == null)
            {
                return NotFound();
            }

            patch.Patch(requestPriority);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestPriorityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestPriority);
        }

        // DELETE: odata/RequestPriorities(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestPriority requestPriority = await db.RequestPriorities.FindAsync(key);
            if (requestPriority == null)
            {
                return NotFound();
            }

            db.RequestPriorities.Remove(requestPriority);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestPriorities(5)/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests([FromODataUri] int key)
        {
            return db.RequestPriorities.Where(m => m.RequestPriorityID == key).SelectMany(m => m.Requests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestPriorityExists(int key)
        {
            return db.RequestPriorities.Count(e => e.RequestPriorityID == key) > 0;
        }
    }
}
