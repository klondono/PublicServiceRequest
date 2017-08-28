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
    public class View_PSRAdmUserAddedController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/View_PSRAdmUserAdded
        [EnableQuery]
        public IQueryable<View_PSRAdmUserAdded> GetView_PSRAdmUserAdded()
        {
            return db.View_PSRAdmUserAdded;
        }

        // GET: odata/View_PSRAdmUserAdded(5)
        [EnableQuery]
        public SingleResult<View_PSRAdmUserAdded> GetView_PSRAdmUserAdded([FromODataUri] long key)
        {
            return SingleResult.Create(db.View_PSRAdmUserAdded.Where(view_PSRAdmUserAdded => view_PSRAdmUserAdded.RN == key));
        }

        // PUT: odata/View_PSRAdmUserAdded(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<View_PSRAdmUserAdded> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_PSRAdmUserAdded view_PSRAdmUserAdded = await db.View_PSRAdmUserAdded.FindAsync(key);
            if (view_PSRAdmUserAdded == null)
            {
                return NotFound();
            }

            patch.Put(view_PSRAdmUserAdded);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_PSRAdmUserAddedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_PSRAdmUserAdded);
        }

        // POST: odata/View_PSRAdmUserAdded
        public async Task<IHttpActionResult> Post(View_PSRAdmUserAdded view_PSRAdmUserAdded)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_PSRAdmUserAdded.Add(view_PSRAdmUserAdded);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (View_PSRAdmUserAddedExists(view_PSRAdmUserAdded.RN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(view_PSRAdmUserAdded);
        }

        // PATCH: odata/View_PSRAdmUserAdded(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<View_PSRAdmUserAdded> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_PSRAdmUserAdded view_PSRAdmUserAdded = await db.View_PSRAdmUserAdded.FindAsync(key);
            if (view_PSRAdmUserAdded == null)
            {
                return NotFound();
            }

            patch.Patch(view_PSRAdmUserAdded);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_PSRAdmUserAddedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_PSRAdmUserAdded);
        }

        // DELETE: odata/View_PSRAdmUserAdded(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            View_PSRAdmUserAdded view_PSRAdmUserAdded = await db.View_PSRAdmUserAdded.FindAsync(key);
            if (view_PSRAdmUserAdded == null)
            {
                return NotFound();
            }

            db.View_PSRAdmUserAdded.Remove(view_PSRAdmUserAdded);
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

        private bool View_PSRAdmUserAddedExists(long key)
        {
            return db.View_PSRAdmUserAdded.Count(e => e.RN == key) > 0;
        }
    }
}
