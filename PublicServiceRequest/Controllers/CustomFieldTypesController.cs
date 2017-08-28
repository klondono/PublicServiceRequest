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
    public class CustomFieldTypesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/CustomFieldTypes
        [EnableQuery]
        public IQueryable<CustomFieldType> GetCustomFieldTypes()
        {
            return db.CustomFieldTypes;
        }

        // GET: odata/CustomFieldTypes(5)
        [EnableQuery]
        public SingleResult<CustomFieldType> GetCustomFieldType([FromODataUri] int key)
        {
            return SingleResult.Create(db.CustomFieldTypes.Where(customFieldType => customFieldType.CustomFieldTypeID == key));
        }

        // PUT: odata/CustomFieldTypes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CustomFieldType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomFieldType customFieldType = await db.CustomFieldTypes.FindAsync(key);
            if (customFieldType == null)
            {
                return NotFound();
            }

            patch.Put(customFieldType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customFieldType);
        }

        // POST: odata/CustomFieldTypes
        public async Task<IHttpActionResult> Post(CustomFieldType customFieldType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomFieldTypes.Add(customFieldType);
            await db.SaveChangesAsync();

            return Created(customFieldType);
        }

        // PATCH: odata/CustomFieldTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CustomFieldType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomFieldType customFieldType = await db.CustomFieldTypes.FindAsync(key);
            if (customFieldType == null)
            {
                return NotFound();
            }

            patch.Patch(customFieldType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customFieldType);
        }

        // DELETE: odata/CustomFieldTypes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CustomFieldType customFieldType = await db.CustomFieldTypes.FindAsync(key);
            if (customFieldType == null)
            {
                return NotFound();
            }

            db.CustomFieldTypes.Remove(customFieldType);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CustomFieldTypes(5)/CustomFieldSelectListItems
        [EnableQuery]
        public IQueryable<CustomFieldSelectListItem> GetCustomFieldSelectListItems([FromODataUri] int key)
        {
            return db.CustomFieldTypes.Where(m => m.CustomFieldTypeID == key).SelectMany(m => m.CustomFieldSelectListItems);
        }

        // GET: odata/CustomFieldTypes(5)/RequestActionTypeCustomFields
        [EnableQuery]
        public IQueryable<RequestActionTypeCustomField> GetRequestActionTypeCustomFields([FromODataUri] int key)
        {
            return db.CustomFieldTypes.Where(m => m.CustomFieldTypeID == key).SelectMany(m => m.RequestActionTypeCustomFields);
        }

        // GET: odata/CustomFieldTypes(5)/ServiceTypeCustomFields
        [EnableQuery]
        public IQueryable<ServiceTypeCustomField> GetServiceTypeCustomFields([FromODataUri] int key)
        {
            return db.CustomFieldTypes.Where(m => m.CustomFieldTypeID == key).SelectMany(m => m.ServiceTypeCustomFields);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomFieldTypeExists(int key)
        {
            return db.CustomFieldTypes.Count(e => e.CustomFieldTypeID == key) > 0;
        }
    }
}
