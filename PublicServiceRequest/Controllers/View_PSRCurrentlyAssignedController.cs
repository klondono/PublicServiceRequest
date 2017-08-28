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

namespace PublicServiceRequest.Controllers
{
    [Authorize]
    public class View_PSRCurrentlyAssignedController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/View_PSRCurrentlyAssigned
        [EnableQuery]
        public IQueryable<View_PSRCurrentlyAssigned> GetView_PSRCurrentlyAssigned()
        {
            return db.View_PSRCurrentlyAssigned;
        }

        // GET: odata/View_PSRCurrentlyAssigned(5)
        [EnableQuery]
        public SingleResult<View_PSRCurrentlyAssigned> GetView_PSRCurrentlyAssigned([FromODataUri] long key)
        {
            return SingleResult.Create(db.View_PSRCurrentlyAssigned.Where(view_PSRCurrentlyAssigned => view_PSRCurrentlyAssigned.RN == key));
        }

        // PUT: odata/View_PSRCurrentlyAssigned(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<View_PSRCurrentlyAssigned> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_PSRCurrentlyAssigned view_PSRCurrentlyAssigned = await db.View_PSRCurrentlyAssigned.FindAsync(key);
            if (view_PSRCurrentlyAssigned == null)
            {
                return NotFound();
            }

            patch.Put(view_PSRCurrentlyAssigned);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_PSRCurrentlyAssignedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_PSRCurrentlyAssigned);
        }

        // POST: odata/View_PSRCurrentlyAssigned
        public async Task<IHttpActionResult> Post(View_PSRCurrentlyAssigned view_PSRCurrentlyAssigned)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_PSRCurrentlyAssigned.Add(view_PSRCurrentlyAssigned);
            await db.SaveChangesAsync();

            return Created(view_PSRCurrentlyAssigned);
        }

        // PATCH: odata/View_PSRCurrentlyAssigned(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<View_PSRCurrentlyAssigned> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_PSRCurrentlyAssigned view_PSRCurrentlyAssigned = await db.View_PSRCurrentlyAssigned.FindAsync(key);
            if (view_PSRCurrentlyAssigned == null)
            {
                return NotFound();
            }

            patch.Patch(view_PSRCurrentlyAssigned);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_PSRCurrentlyAssignedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_PSRCurrentlyAssigned);
        }

        // DELETE: odata/View_PSRCurrentlyAssigned(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            View_PSRCurrentlyAssigned view_PSRCurrentlyAssigned = await db.View_PSRCurrentlyAssigned.FindAsync(key);
            if (view_PSRCurrentlyAssigned == null)
            {
                return NotFound();
            }

            db.View_PSRCurrentlyAssigned.Remove(view_PSRCurrentlyAssigned);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool View_PSRCurrentlyAssignedExists(long key)
        {
            return db.View_PSRCurrentlyAssigned.Count(e => e.RN == key) > 0;
        }
    }
}
