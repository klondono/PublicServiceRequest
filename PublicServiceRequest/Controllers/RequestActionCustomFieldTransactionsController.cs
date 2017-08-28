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
    public class RequestActionCustomFieldTransactionsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestActionCustomFieldTransactions
        [EnableQuery]
        public IQueryable<RequestActionCustomFieldTransaction> GetRequestActionCustomFieldTransactions()
        {
            return db.RequestActionCustomFieldTransactions;
        }

        // GET: odata/RequestActionCustomFieldTransactions(5)
        [EnableQuery]
        public SingleResult<RequestActionCustomFieldTransaction> GetRequestActionCustomFieldTransaction([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionCustomFieldTransactions.Where(requestActionCustomFieldTransaction => requestActionCustomFieldTransaction.RequestActionCustomFieldTransactionID == key));
        }

        // PUT: odata/RequestActionCustomFieldTransactions(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestActionCustomFieldTransaction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestActionCustomFieldTransaction requestActionCustomFieldTransaction = await db.RequestActionCustomFieldTransactions.FindAsync(key);
            if (requestActionCustomFieldTransaction == null)
            {
                return NotFound();
            }

            patch.Put(requestActionCustomFieldTransaction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestActionCustomFieldTransactionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestActionCustomFieldTransaction);
        }

        // POST: odata/RequestActionCustomFieldTransactions
        public async Task<IHttpActionResult> Post(RequestActionCustomFieldTransaction requestActionCustomFieldTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestActionCustomFieldTransactions.Add(requestActionCustomFieldTransaction);
            await db.SaveChangesAsync();

            return Created(requestActionCustomFieldTransaction);
        }

        // PATCH: odata/RequestActionCustomFieldTransactions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestActionCustomFieldTransaction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestActionCustomFieldTransaction requestActionCustomFieldTransaction = await db.RequestActionCustomFieldTransactions.FindAsync(key);
            if (requestActionCustomFieldTransaction == null)
            {
                return NotFound();
            }

            patch.Patch(requestActionCustomFieldTransaction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestActionCustomFieldTransactionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestActionCustomFieldTransaction);
        }

        // DELETE: odata/RequestActionCustomFieldTransactions(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestActionCustomFieldTransaction requestActionCustomFieldTransaction = await db.RequestActionCustomFieldTransactions.FindAsync(key);
            if (requestActionCustomFieldTransaction == null)
            {
                return NotFound();
            }

            db.RequestActionCustomFieldTransactions.Remove(requestActionCustomFieldTransaction);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestActionCustomFieldTransactions(5)/RequestAction
        [EnableQuery]
        public SingleResult<RequestAction> GetRequestAction([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionCustomFieldTransactions.Where(m => m.RequestActionCustomFieldTransactionID == key).Select(m => m.RequestAction));
        }

        // GET: odata/RequestActionCustomFieldTransactions(5)/RequestActionTypeCustomField
        [EnableQuery]
        public SingleResult<RequestActionTypeCustomField> GetRequestActionTypeCustomField([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionCustomFieldTransactions.Where(m => m.RequestActionCustomFieldTransactionID == key).Select(m => m.RequestActionTypeCustomField));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestActionCustomFieldTransactionExists(int key)
        {
            return db.RequestActionCustomFieldTransactions.Count(e => e.RequestActionCustomFieldTransactionID == key) > 0;
        }
    }
}
