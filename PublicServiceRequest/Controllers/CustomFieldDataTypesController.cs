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
    public class CustomFieldDataTypesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/CustomFieldDataTypes
        [EnableQuery]
        public IQueryable<CustomFieldDataType> GetCustomFieldDataTypes()
        {
            return db.CustomFieldDataTypes;
        }

        // GET: odata/CustomFieldDataTypes(5)
        [EnableQuery]
        public SingleResult<CustomFieldDataType> GetCustomFieldDataType([FromODataUri] int key)
        {
            return SingleResult.Create(db.CustomFieldDataTypes.Where(customFieldDataType => customFieldDataType.CustomFieldDataTypeID == key));
        }

        // PUT: odata/CustomFieldDataTypes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CustomFieldDataType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomFieldDataType customFieldDataType = await db.CustomFieldDataTypes.FindAsync(key);
            if (customFieldDataType == null)
            {
                return NotFound();
            }

            patch.Put(customFieldDataType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldDataTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customFieldDataType);
        }

        // POST: odata/CustomFieldDataTypes
        public async Task<IHttpActionResult> Post(CustomFieldDataType customFieldDataType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomFieldDataTypes.Add(customFieldDataType);
            await db.SaveChangesAsync();

            return Created(customFieldDataType);
        }

        // PATCH: odata/CustomFieldDataTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CustomFieldDataType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomFieldDataType customFieldDataType = await db.CustomFieldDataTypes.FindAsync(key);
            if (customFieldDataType == null)
            {
                return NotFound();
            }

            patch.Patch(customFieldDataType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldDataTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customFieldDataType);
        }

        // DELETE: odata/CustomFieldDataTypes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CustomFieldDataType customFieldDataType = await db.CustomFieldDataTypes.FindAsync(key);
            if (customFieldDataType == null)
            {
                return NotFound();
            }

            db.CustomFieldDataTypes.Remove(customFieldDataType);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CustomFieldDataTypes(5)/RequestActionTypeCustomFields
        [EnableQuery]
        public IQueryable<RequestActionTypeCustomField> GetRequestActionTypeCustomFields([FromODataUri] int key)
        {
            return db.CustomFieldDataTypes.Where(m => m.CustomFieldDataTypeID == key).SelectMany(m => m.RequestActionTypeCustomFields);
        }

        // GET: odata/CustomFieldDataTypes(5)/ServiceTypeCustomFields
        [EnableQuery]
        public IQueryable<ServiceTypeCustomField> GetServiceTypeCustomFields([FromODataUri] int key)
        {
            return db.CustomFieldDataTypes.Where(m => m.CustomFieldDataTypeID == key).SelectMany(m => m.ServiceTypeCustomFields);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomFieldDataTypeExists(int key)
        {
            return db.CustomFieldDataTypes.Count(e => e.CustomFieldDataTypeID == key) > 0;
        }
    }
}
