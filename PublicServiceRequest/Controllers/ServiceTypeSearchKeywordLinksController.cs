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
    public class ServiceTypeSearchKeywordLinksController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/ServiceTypeSearchKeywordLinks
        [EnableQuery]
        public IQueryable<ServiceTypeSearchKeywordLink> GetServiceTypeSearchKeywordLinks()
        {
            return db.ServiceTypeSearchKeywordLinks;
        }

        // GET: odata/ServiceTypeSearchKeywordLinks(5)
        [EnableQuery]
        public SingleResult<ServiceTypeSearchKeywordLink> GetServiceTypeSearchKeywordLink([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeSearchKeywordLinks.Where(serviceTypeSearchKeywordLink => serviceTypeSearchKeywordLink.ServiceTypeSearchKeywordLinkID == key));
        }

        // PUT: odata/ServiceTypeSearchKeywordLinks(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ServiceTypeSearchKeywordLink> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeSearchKeywordLink serviceTypeSearchKeywordLink = await db.ServiceTypeSearchKeywordLinks.FindAsync(key);
            if (serviceTypeSearchKeywordLink == null)
            {
                return NotFound();
            }

            patch.Put(serviceTypeSearchKeywordLink);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeSearchKeywordLinkExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeSearchKeywordLink);
        }

        // POST: odata/ServiceTypeSearchKeywordLinks
        public async Task<IHttpActionResult> Post(ServiceTypeSearchKeywordLink serviceTypeSearchKeywordLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypeSearchKeywordLinks.Add(serviceTypeSearchKeywordLink);
            await db.SaveChangesAsync();

            return Created(serviceTypeSearchKeywordLink);
        }

        // PATCH: odata/ServiceTypeSearchKeywordLinks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ServiceTypeSearchKeywordLink> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeSearchKeywordLink serviceTypeSearchKeywordLink = await db.ServiceTypeSearchKeywordLinks.FindAsync(key);
            if (serviceTypeSearchKeywordLink == null)
            {
                return NotFound();
            }

            patch.Patch(serviceTypeSearchKeywordLink);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeSearchKeywordLinkExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeSearchKeywordLink);
        }

        // DELETE: odata/ServiceTypeSearchKeywordLinks(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceTypeSearchKeywordLink serviceTypeSearchKeywordLink = await db.ServiceTypeSearchKeywordLinks.FindAsync(key);
            if (serviceTypeSearchKeywordLink == null)
            {
                return NotFound();
            }

            db.ServiceTypeSearchKeywordLinks.Remove(serviceTypeSearchKeywordLink);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypeSearchKeywordLinks(5)/ServiceType
        [EnableQuery]
        public SingleResult<ServiceType> GetServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeSearchKeywordLinks.Where(m => m.ServiceTypeSearchKeywordLinkID == key).Select(m => m.ServiceType));
        }

        // GET: odata/ServiceTypeSearchKeywordLinks(5)/ServiceTypeSearchKeyword
        [EnableQuery]
        public SingleResult<ServiceTypeSearchKeyword> GetServiceTypeSearchKeyword([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeSearchKeywordLinks.Where(m => m.ServiceTypeSearchKeywordLinkID == key).Select(m => m.ServiceTypeSearchKeyword));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeSearchKeywordLinkExists(int key)
        {
            return db.ServiceTypeSearchKeywordLinks.Count(e => e.ServiceTypeSearchKeywordLinkID == key) > 0;
        }
    }
}
