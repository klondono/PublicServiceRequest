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
    public class ServiceTypeResolutionsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/ServiceTypeResolutions
        [EnableQuery]
        public IQueryable<ServiceTypeResolution> GetServiceTypeResolutions()
        {
            return db.ServiceTypeResolutions;
        }

        // GET: odata/ServiceTypeResolutions(5)
        [EnableQuery]
        public SingleResult<ServiceTypeResolution> GetServiceTypeResolution([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeResolutions.Where(serviceTypeResolution => serviceTypeResolution.ServiceTypeResolutionID == key));
        }

        // PUT: odata/ServiceTypeResolutions(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ServiceTypeResolution> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeResolution serviceTypeResolution = await db.ServiceTypeResolutions.FindAsync(key);
            if (serviceTypeResolution == null)
            {
                return NotFound();
            }

            patch.Put(serviceTypeResolution);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeResolutionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeResolution);
        }

        // POST: odata/ServiceTypeResolutions
        public async Task<IHttpActionResult> Post(ServiceTypeResolution serviceTypeResolution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypeResolutions.Add(serviceTypeResolution);
            await db.SaveChangesAsync();

            return Created(serviceTypeResolution);
        }

        // PATCH: odata/ServiceTypeResolutions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ServiceTypeResolution> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeResolution serviceTypeResolution = await db.ServiceTypeResolutions.FindAsync(key);
            if (serviceTypeResolution == null)
            {
                return NotFound();
            }

            patch.Patch(serviceTypeResolution);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeResolutionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeResolution);
        }

        // DELETE: odata/ServiceTypeResolutions(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceTypeResolution serviceTypeResolution = await db.ServiceTypeResolutions.FindAsync(key);
            if (serviceTypeResolution == null)
            {
                return NotFound();
            }

            db.ServiceTypeResolutions.Remove(serviceTypeResolution);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypeResolutions(5)/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests([FromODataUri] int key)
        {
            return db.ServiceTypeResolutions.Where(m => m.ServiceTypeResolutionID == key).SelectMany(m => m.Requests);
        }

        // GET: odata/ServiceTypeResolutions(5)/ServiceTypeResolutionLinks
        [EnableQuery]
        public IQueryable<ServiceTypeResolutionLink> GetServiceTypeResolutionLinks([FromODataUri] int key)
        {
            return db.ServiceTypeResolutions.Where(m => m.ServiceTypeResolutionID == key).SelectMany(m => m.ServiceTypeResolutionLinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeResolutionExists(int key)
        {
            return db.ServiceTypeResolutions.Count(e => e.ServiceTypeResolutionID == key) > 0;
        }
    }
}
