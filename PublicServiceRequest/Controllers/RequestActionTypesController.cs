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
    public class RequestActionTypesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestActionTypes
        [EnableQuery]
        public IQueryable<RequestActionType> GetRequestActionTypes()
        {
            return db.RequestActionTypes;
        }

        // GET: odata/RequestActionTypes(5)
        [EnableQuery]
        public SingleResult<RequestActionType> GetRequestActionType([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionTypes.Where(requestActionType => requestActionType.RequestActionTypeID == key));
        }

        // PUT: odata/RequestActionTypes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestActionType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestActionType requestActionType = await db.RequestActionTypes.FindAsync(key);
            if (requestActionType == null)
            {
                return NotFound();
            }

            patch.Put(requestActionType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestActionTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestActionType);
        }

        // POST: odata/RequestActionTypes
        public async Task<IHttpActionResult> Post(RequestActionType requestActionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestActionTypes.Add(requestActionType);
            await db.SaveChangesAsync();

            return Created(requestActionType);
        }

        // PATCH: odata/RequestActionTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestActionType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestActionType requestActionType = await db.RequestActionTypes.FindAsync(key);
            if (requestActionType == null)
            {
                return NotFound();
            }

            patch.Patch(requestActionType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestActionTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestActionType);
        }

        // DELETE: odata/RequestActionTypes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestActionType requestActionType = await db.RequestActionTypes.FindAsync(key);
            if (requestActionType == null)
            {
                return NotFound();
            }

            db.RequestActionTypes.Remove(requestActionType);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestActionTypes(5)/RequestActions
        [EnableQuery]
        public IQueryable<RequestAction> GetRequestActions([FromODataUri] int key)
        {
            return db.RequestActionTypes.Where(m => m.RequestActionTypeID == key).SelectMany(m => m.RequestActions);
        }

        // GET: odata/RequestActionTypes(5)/RequestActionTypeCustomFields
        [EnableQuery]
        public IQueryable<RequestActionTypeCustomField> GetRequestActionTypeCustomFields([FromODataUri] int key)
        {
            return db.RequestActionTypes.Where(m => m.RequestActionTypeID == key).SelectMany(m => m.RequestActionTypeCustomFields);
        }

        //// GET: odata/RequestActionTypes(5)/ServiceTypeCustomFieldTransactions
        //[EnableQuery]
        //public IQueryable<ServiceTypeCustomFieldTransaction> GetServiceTypeCustomFieldTransactions([FromODataUri] int key)
        //{
        //    return db.RequestActionTypes.Where(m => m.RequestActionTypeID == key).SelectMany(m => m.ServiceTypeCustomFieldTransactions);
        //}

        // GET: odata/RequestActionTypes(5)/ServiceTypeRequestActionTypeLinks
        [EnableQuery]
        public IQueryable<ServiceTypeRequestActionTypeLink> GetServiceTypeRequestActionTypeLinks([FromODataUri] int key)
        {
            return db.RequestActionTypes.Where(m => m.RequestActionTypeID == key).SelectMany(m => m.ServiceTypeRequestActionTypeLinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestActionTypeExists(int key)
        {
            return db.RequestActionTypes.Count(e => e.RequestActionTypeID == key) > 0;
        }
    }
}
