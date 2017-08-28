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
    public class RequestStatusController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestStatus
        [EnableQuery]
        public IQueryable<RequestStatus> GetRequestStatus()
        {
            return db.RequestStatuses;
        }

        // GET: odata/RequestStatus(5)
        [EnableQuery]
        public SingleResult<RequestStatus> GetRequestStatus([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestStatuses.Where(requestStatus => requestStatus.RequestStatusID == key));
        }

        // PUT: odata/RequestStatus(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestStatus> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestStatus requestStatus = await db.RequestStatuses.FindAsync(key);
            if (requestStatus == null)
            {
                return NotFound();
            }

            patch.Put(requestStatus);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestStatusExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestStatus);
        }

        // POST: odata/RequestStatus
        public async Task<IHttpActionResult> Post(RequestStatus requestStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestStatuses.Add(requestStatus);
            await db.SaveChangesAsync();

            return Created(requestStatus);
        }

        // PATCH: odata/RequestStatus(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestStatus> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestStatus requestStatus = await db.RequestStatuses.FindAsync(key);
            if (requestStatus == null)
            {
                return NotFound();
            }

            patch.Patch(requestStatus);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestStatusExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestStatus);
        }

        // DELETE: odata/RequestStatus(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestStatus requestStatus = await db.RequestStatuses.FindAsync(key);
            if (requestStatus == null)
            {
                return NotFound();
            }

            db.RequestStatuses.Remove(requestStatus);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestStatus(5)/RequestActions
        [EnableQuery]
        public IQueryable<RequestAction> GetRequestActions([FromODataUri] int key)
        {
            return db.RequestStatuses.Where(m => m.RequestStatusID == key).SelectMany(m => m.RequestActions);
        }

        // GET: odata/RequestStatus(5)/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests([FromODataUri] int key)
        {
            return db.RequestStatuses.Where(m => m.RequestStatusID == key).SelectMany(m => m.Requests);
        }

        // GET: odata/RequestStatus(5)/ServiceTypes_DefaultRequestStatus
        [EnableQuery]
        public IQueryable<ServiceType> GetServiceTypes_DefaultRequestStatus([FromODataUri] int key)
        {
            return db.RequestStatuses.Where(m => m.RequestStatusID == key).SelectMany(m => m.ServiceTypes_DefaultRequestStatus);
        }

        // GET: odata/RequestStatus(5)/ServiceTypes_EscalationExpectedStatus
        [EnableQuery]
        public IQueryable<ServiceType> GetServiceTypes_EscalationExpectedStatus([FromODataUri] int key)
        {
            return db.RequestStatuses.Where(m => m.RequestStatusID == key).SelectMany(m => m.ServiceTypes_EscalationExpectedStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestStatusExists(int key)
        {
            return db.RequestStatuses.Count(e => e.RequestStatusID == key) > 0;
        }
    }
}
