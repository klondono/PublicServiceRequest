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
    public class View_RequestFolioByRequestNumberAndYearController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/View_RequestFolioByRequestNumberAndYear
        [EnableQuery]
        public IQueryable<View_RequestFolioByRequestNumberAndYear> GetView_RequestFolioByRequestNumberAndYear()
        {
            return db.View_RequestFolioByRequestNumberAndYear;
        }

        // GET: odata/View_RequestFolioByRequestNumberAndYear(5)
        [EnableQuery]
        public SingleResult<View_RequestFolioByRequestNumberAndYear> GetView_RequestFolioByRequestNumberAndYear([FromODataUri] int key)
        {
            return SingleResult.Create(db.View_RequestFolioByRequestNumberAndYear.Where(view_RequestFolioByRequestNumberAndYear => view_RequestFolioByRequestNumberAndYear.RequestFolioID == key));
        }

        // PUT: odata/View_RequestFolioByRequestNumberAndYear(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<View_RequestFolioByRequestNumberAndYear> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_RequestFolioByRequestNumberAndYear view_RequestFolioByRequestNumberAndYear = await db.View_RequestFolioByRequestNumberAndYear.FindAsync(key);
            if (view_RequestFolioByRequestNumberAndYear == null)
            {
                return NotFound();
            }

            patch.Put(view_RequestFolioByRequestNumberAndYear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_RequestFolioByRequestNumberAndYearExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_RequestFolioByRequestNumberAndYear);
        }

        // POST: odata/View_RequestFolioByRequestNumberAndYear
        public async Task<IHttpActionResult> Post(View_RequestFolioByRequestNumberAndYear view_RequestFolioByRequestNumberAndYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_RequestFolioByRequestNumberAndYear.Add(view_RequestFolioByRequestNumberAndYear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (View_RequestFolioByRequestNumberAndYearExists(view_RequestFolioByRequestNumberAndYear.RequestFolioID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(view_RequestFolioByRequestNumberAndYear);
        }

        // PATCH: odata/View_RequestFolioByRequestNumberAndYear(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<View_RequestFolioByRequestNumberAndYear> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_RequestFolioByRequestNumberAndYear view_RequestFolioByRequestNumberAndYear = await db.View_RequestFolioByRequestNumberAndYear.FindAsync(key);
            if (view_RequestFolioByRequestNumberAndYear == null)
            {
                return NotFound();
            }

            patch.Patch(view_RequestFolioByRequestNumberAndYear);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_RequestFolioByRequestNumberAndYearExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_RequestFolioByRequestNumberAndYear);
        }

        // DELETE: odata/View_RequestFolioByRequestNumberAndYear(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            View_RequestFolioByRequestNumberAndYear view_RequestFolioByRequestNumberAndYear = await db.View_RequestFolioByRequestNumberAndYear.FindAsync(key);
            if (view_RequestFolioByRequestNumberAndYear == null)
            {
                return NotFound();
            }

            db.View_RequestFolioByRequestNumberAndYear.Remove(view_RequestFolioByRequestNumberAndYear);
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

        private bool View_RequestFolioByRequestNumberAndYearExists(int key)
        {
            return db.View_RequestFolioByRequestNumberAndYear.Count(e => e.RequestFolioID == key) > 0;
        }
    }
}
