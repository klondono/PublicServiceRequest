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
    public class ServiceTypeSearchKeywordsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/ServiceTypeSearchKeywords
        [EnableQuery]
        public IQueryable<ServiceTypeSearchKeyword> GetServiceTypeSearchKeywords()
        {
            return db.ServiceTypeSearchKeywords;
        }

        // GET: odata/ServiceTypeSearchKeywords(5)
        [EnableQuery]
        public SingleResult<ServiceTypeSearchKeyword> GetServiceTypeSearchKeyword([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypeSearchKeywords.Where(serviceTypeSearchKeyword => serviceTypeSearchKeyword.ServiceTypeSearchKeywordID == key));
        }

        // PUT: odata/ServiceTypeSearchKeywords(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ServiceTypeSearchKeyword> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeSearchKeyword serviceTypeSearchKeyword = await db.ServiceTypeSearchKeywords.FindAsync(key);
            if (serviceTypeSearchKeyword == null)
            {
                return NotFound();
            }

            patch.Put(serviceTypeSearchKeyword);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeSearchKeywordExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeSearchKeyword);
        }

        // POST: odata/ServiceTypeSearchKeywords
        public async Task<IHttpActionResult> Post(ServiceTypeSearchKeyword serviceTypeSearchKeyword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypeSearchKeywords.Add(serviceTypeSearchKeyword);
            await db.SaveChangesAsync();

            return Created(serviceTypeSearchKeyword);
        }

        // PATCH: odata/ServiceTypeSearchKeywords(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ServiceTypeSearchKeyword> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeSearchKeyword serviceTypeSearchKeyword = await db.ServiceTypeSearchKeywords.FindAsync(key);
            if (serviceTypeSearchKeyword == null)
            {
                return NotFound();
            }

            patch.Patch(serviceTypeSearchKeyword);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeSearchKeywordExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeSearchKeyword);
        }

        // DELETE: odata/ServiceTypeSearchKeywords(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceTypeSearchKeyword serviceTypeSearchKeyword = await db.ServiceTypeSearchKeywords.FindAsync(key);
            if (serviceTypeSearchKeyword == null)
            {
                return NotFound();
            }

            db.ServiceTypeSearchKeywords.Remove(serviceTypeSearchKeyword);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypeSearchKeywords(5)/ServiceTypeSearchKeywordLinks
        [EnableQuery]
        public IQueryable<ServiceTypeSearchKeywordLink> GetServiceTypeSearchKeywordLinks([FromODataUri] int key)
        {
            return db.ServiceTypeSearchKeywords.Where(m => m.ServiceTypeSearchKeywordID == key).SelectMany(m => m.ServiceTypeSearchKeywordLinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeSearchKeywordExists(int key)
        {
            return db.ServiceTypeSearchKeywords.Count(e => e.ServiceTypeSearchKeywordID == key) > 0;
        }
    }
}
