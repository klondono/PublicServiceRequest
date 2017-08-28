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
    public class CustomFieldSelectListItemsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/CustomFieldSelectListItems
        [EnableQuery]
        public IQueryable<CustomFieldSelectListItem> GetCustomFieldSelectListItems()
        {
            return db.CustomFieldSelectListItems;
        }

        // GET: odata/CustomFieldSelectListItems(5)
        [EnableQuery]
        public SingleResult<CustomFieldSelectListItem> GetCustomFieldSelectListItem([FromODataUri] int key)
        {
            return SingleResult.Create(db.CustomFieldSelectListItems.Where(customFieldSelectListItem => customFieldSelectListItem.CustomFieldSelectListItemID == key));
        }

        // PUT: odata/CustomFieldSelectListItems(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<CustomFieldSelectListItem> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomFieldSelectListItem customFieldSelectListItem = await db.CustomFieldSelectListItems.FindAsync(key);
            if (customFieldSelectListItem == null)
            {
                return NotFound();
            }

            patch.Put(customFieldSelectListItem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldSelectListItemExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customFieldSelectListItem);
        }

        // POST: odata/CustomFieldSelectListItems
        public async Task<IHttpActionResult> Post(CustomFieldSelectListItem customFieldSelectListItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomFieldSelectListItems.Add(customFieldSelectListItem);
            await db.SaveChangesAsync();

            return Created(customFieldSelectListItem);
        }

        // PATCH: odata/CustomFieldSelectListItems(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CustomFieldSelectListItem> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomFieldSelectListItem customFieldSelectListItem = await db.CustomFieldSelectListItems.FindAsync(key);
            if (customFieldSelectListItem == null)
            {
                return NotFound();
            }

            patch.Patch(customFieldSelectListItem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomFieldSelectListItemExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(customFieldSelectListItem);
        }

        // DELETE: odata/CustomFieldSelectListItems(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            CustomFieldSelectListItem customFieldSelectListItem = await db.CustomFieldSelectListItems.FindAsync(key);
            if (customFieldSelectListItem == null)
            {
                return NotFound();
            }

            db.CustomFieldSelectListItems.Remove(customFieldSelectListItem);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/CustomFieldSelectListItems(5)/CustomFieldType
        [EnableQuery]
        public SingleResult<CustomFieldType> GetCustomFieldType([FromODataUri] int key)
        {
            return SingleResult.Create(db.CustomFieldSelectListItems.Where(m => m.CustomFieldSelectListItemID == key).Select(m => m.CustomFieldType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomFieldSelectListItemExists(int key)
        {
            return db.CustomFieldSelectListItems.Count(e => e.CustomFieldSelectListItemID == key) > 0;
        }
    }
}
