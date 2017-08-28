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
    public class ServiceTypeCustomFieldsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/ServiceTypeCustomFields
        [EnableQuery]
        public IQueryable<ServiceTypeCustomField> GetServiceTypeCustomFields()
        {
            return db.ServiceTypeCustomFields;
        }

        // GET: odata/ServiceTypeCustomFields(5)
        [EnableQuery]
        public SingleResult<ServiceTypeCustomField> GetServiceTypeCustomField([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFields.Where(serviceTypeCustomField => serviceTypeCustomField.ServiceTypeCustomFieldID == key));
        }

        // PUT: odata/ServiceTypeCustomFields(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ServiceTypeCustomField> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeCustomField serviceTypeCustomField = await db.ServiceTypeCustomFields.FindAsync(key);
            if (serviceTypeCustomField == null)
            {
                return NotFound();
            }

            patch.Put(serviceTypeCustomField);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeCustomFieldExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeCustomField);
        }

        // POST: odata/ServiceTypeCustomFields
        public async Task<IHttpActionResult> Post(ServiceTypeCustomField serviceTypeCustomField)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypeCustomFields.Add(serviceTypeCustomField);
            await db.SaveChangesAsync();

            return Created(serviceTypeCustomField);
        }

        // PATCH: odata/ServiceTypeCustomFields(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ServiceTypeCustomField> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeCustomField serviceTypeCustomField = await db.ServiceTypeCustomFields.FindAsync(key);
            if (serviceTypeCustomField == null)
            {
                return NotFound();
            }

            patch.Patch(serviceTypeCustomField);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeCustomFieldExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeCustomField);
        }

        // DELETE: odata/ServiceTypeCustomFields(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceTypeCustomField serviceTypeCustomField = await db.ServiceTypeCustomFields.FindAsync(key);
            if (serviceTypeCustomField == null)
            {
                return NotFound();
            }

            db.ServiceTypeCustomFields.Remove(serviceTypeCustomField);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypeCustomFields(5)/CustomFieldDataType
        [EnableQuery]
        public SingleResult<CustomFieldDataType> GetCustomFieldDataType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFields.Where(m => m.ServiceTypeCustomFieldID == key).Select(m => m.CustomFieldDataType));
        }

        // GET: odata/ServiceTypeCustomFields(5)/CustomFieldType
        [EnableQuery]
        public SingleResult<CustomFieldType> GetCustomFieldType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFields.Where(m => m.ServiceTypeCustomFieldID == key).Select(m => m.CustomFieldType));
        }

        // GET: odata/ServiceTypeCustomFields(5)/ServiceType
        [EnableQuery]
        public SingleResult<ServiceType> GetServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeCustomFields.Where(m => m.ServiceTypeCustomFieldID == key).Select(m => m.ServiceType));
        }

        // GET: odata/ServiceTypeCustomFields(5)/ServiceTypeCustomFieldTransactions
        [EnableQuery]
        public IQueryable<ServiceTypeCustomFieldTransaction> GetServiceTypeCustomFieldTransactions([FromODataUri] int key)
        {
            return db.ServiceTypeCustomFields.Where(m => m.ServiceTypeCustomFieldID == key).SelectMany(m => m.ServiceTypeCustomFieldTransactions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeCustomFieldExists(int key)
        {
            return db.ServiceTypeCustomFields.Count(e => e.ServiceTypeCustomFieldID == key) > 0;
        }
    }
}
