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
    public class ServiceTypeCustomFieldTransactionsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/ServiceTypeCustomFieldTransactions
        [EnableQuery]
        public IQueryable<ServiceTypeCustomFieldTransaction> GetServiceTypeCustomFieldTransactions()
        {
            return db.ServiceTypeCustomFieldTransactions;
        }

        // GET: odata/ServiceTypeCustomFieldTransactions(5)
        [EnableQuery]
        public SingleResult<ServiceTypeCustomFieldTransaction> GetServiceTypeCustomFieldTransaction([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFieldTransactions.Where(serviceTypeCustomFieldTransaction => serviceTypeCustomFieldTransaction.ServiceTypeCustomFieldTransactionID == key));
        }

        // PUT: odata/ServiceTypeCustomFieldTransactions(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ServiceTypeCustomFieldTransaction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeCustomFieldTransaction serviceTypeCustomFieldTransaction = await db.ServiceTypeCustomFieldTransactions.FindAsync(key);
            if (serviceTypeCustomFieldTransaction == null)
            {
                return NotFound();
            }

            patch.Put(serviceTypeCustomFieldTransaction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeCustomFieldTransactionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeCustomFieldTransaction);
        }

        // POST: odata/ServiceTypeCustomFieldTransactions
        public async Task<IHttpActionResult> Post(ServiceTypeCustomFieldTransaction serviceTypeCustomFieldTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypeCustomFieldTransactions.Add(serviceTypeCustomFieldTransaction);
            await db.SaveChangesAsync();

            return Created(serviceTypeCustomFieldTransaction);
        }

        // PATCH: odata/ServiceTypeCustomFieldTransactions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ServiceTypeCustomFieldTransaction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeCustomFieldTransaction serviceTypeCustomFieldTransaction = await db.ServiceTypeCustomFieldTransactions.FindAsync(key);
            if (serviceTypeCustomFieldTransaction == null)
            {
                return NotFound();
            }

            patch.Patch(serviceTypeCustomFieldTransaction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeCustomFieldTransactionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeCustomFieldTransaction);
        }

        // DELETE: odata/ServiceTypeCustomFieldTransactions(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceTypeCustomFieldTransaction serviceTypeCustomFieldTransaction = await db.ServiceTypeCustomFieldTransactions.FindAsync(key);
            if (serviceTypeCustomFieldTransaction == null)
            {
                return NotFound();
            }

            db.ServiceTypeCustomFieldTransactions.Remove(serviceTypeCustomFieldTransaction);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypeCustomFieldTransactions(5)/Request
        [EnableQuery]
        public SingleResult<Request> GetRequest([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFieldTransactions.Where(m => m.ServiceTypeCustomFieldTransactionID == key).Select(m => m.Request));
        }

        //// GET: odata/ServiceTypeCustomFieldTransactions(5)/RequestActionType
        //[EnableQuery]
        //public SingleResult<RequestActionType> GetRequestActionType([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.ServiceTypeCustomFieldTransactions.Where(m => m.ServiceTypeCustomFieldTransactionID == key).Select(m => m.RequestActionType));
        //}

        // GET: odata/ServiceTypeCustomFieldTransactions(5)/ServiceType
        //[EnableQuery]
        //public SingleResult<ServiceType> GetServiceType([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.ServiceTypeCustomFieldTransactions.Where(m => m.ServiceTypeCustomFieldTransactionID == key).Select(m => m.ServiceType));
        //}

        // GET: odata/ServiceTypeCustomFieldTransactions(5)/ServiceTypeCustomField
        [EnableQuery]
        public SingleResult<ServiceTypeCustomField> GetServiceTypeCustomField([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFieldTransactions.Where(m => m.ServiceTypeCustomFieldTransactionID == key).Select(m => m.ServiceTypeCustomField));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeCustomFieldTransactionExists(int key)
        {
            return db.ServiceTypeCustomFieldTransactions.Count(e => e.ServiceTypeCustomFieldTransactionID == key) > 0;
        }
    }
}
