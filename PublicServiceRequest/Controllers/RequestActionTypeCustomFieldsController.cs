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
    public class RequestActionTypeCustomFieldsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestActionTypeCustomFields
        [EnableQuery]
        public IQueryable<RequestActionTypeCustomField> GetRequestActionTypeCustomFields()
        {
            return db.RequestActionTypeCustomFields;
        }

        // GET: odata/RequestActionTypeCustomFields(5)
        [EnableQuery]
        public SingleResult<RequestActionTypeCustomField> GetRequestActionTypeCustomField([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionTypeCustomFields.Where(requestActionTypeCustomField => requestActionTypeCustomField.RequestActionTypeCustomFieldID == key));
        }

        // PUT: odata/RequestActionTypeCustomFields(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestActionTypeCustomField> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestActionTypeCustomField requestActionTypeCustomField = await db.RequestActionTypeCustomFields.FindAsync(key);
            if (requestActionTypeCustomField == null)
            {
                return NotFound();
            }

            patch.Put(requestActionTypeCustomField);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestActionTypeCustomFieldExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestActionTypeCustomField);
        }

        // POST: odata/RequestActionTypeCustomFields
        public async Task<IHttpActionResult> Post(RequestActionTypeCustomField requestActionTypeCustomField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestActionTypeCustomFields.Add(requestActionTypeCustomField);
            await db.SaveChangesAsync();

            return Created(requestActionTypeCustomField);
        }

        // PATCH: odata/RequestActionTypeCustomFields(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestActionTypeCustomField> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestActionTypeCustomField requestActionTypeCustomField = await db.RequestActionTypeCustomFields.FindAsync(key);
            if (requestActionTypeCustomField == null)
            {
                return NotFound();
            }

            patch.Patch(requestActionTypeCustomField);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestActionTypeCustomFieldExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestActionTypeCustomField);
        }

        // DELETE: odata/RequestActionTypeCustomFields(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestActionTypeCustomField requestActionTypeCustomField = await db.RequestActionTypeCustomFields.FindAsync(key);
            if (requestActionTypeCustomField == null)
            {
                return NotFound();
            }

            db.RequestActionTypeCustomFields.Remove(requestActionTypeCustomField);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestActionTypeCustomFields(5)/CustomFieldDataType
        [EnableQuery]
        public SingleResult<CustomFieldDataType> GetCustomFieldDataType([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionTypeCustomFields.Where(m => m.RequestActionTypeCustomFieldID == key).Select(m => m.CustomFieldDataType));
        }

        // GET: odata/RequestActionTypeCustomFields(5)/CustomFieldType
        [EnableQuery]
        public SingleResult<CustomFieldType> GetCustomFieldType([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionTypeCustomFields.Where(m => m.RequestActionTypeCustomFieldID == key).Select(m => m.CustomFieldType));
        }

        // GET: odata/RequestActionTypeCustomFields(5)/RequestActionCustomFieldTransactions
        [EnableQuery]
        public IQueryable<RequestActionCustomFieldTransaction> GetRequestActionCustomFieldTransactions([FromODataUri] int key)
        {
            return db.RequestActionTypeCustomFields.Where(m => m.RequestActionTypeCustomFieldID == key).SelectMany(m => m.RequestActionCustomFieldTransactions);
        }

        // GET: odata/RequestActionTypeCustomFields(5)/RequestActionType
        [EnableQuery]
        public SingleResult<RequestActionType> GetRequestActionType([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestActionTypeCustomFields.Where(m => m.RequestActionTypeCustomFieldID == key).Select(m => m.RequestActionType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestActionTypeCustomFieldExists(int key)
        {
            return db.RequestActionTypeCustomFields.Count(e => e.RequestActionTypeCustomFieldID == key) > 0;
        }
    }
}
