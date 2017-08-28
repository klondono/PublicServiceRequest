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
    public class RequestTaxpayerPreferredLanguagesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestTaxpayerPreferredLanguages
        [EnableQuery]
        public IQueryable<RequestTaxpayerPreferredLanguage> GetRequestTaxpayerPreferredLanguages()
        {
            return db.RequestTaxpayerPreferredLanguages;
        }

        // GET: odata/RequestTaxpayerPreferredLanguages(5)
        [EnableQuery]
        public SingleResult<RequestTaxpayerPreferredLanguage> GetRequestTaxpayerPreferredLanguage([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestTaxpayerPreferredLanguages.Where(requestTaxpayerPreferredLanguage => requestTaxpayerPreferredLanguage.RequestTaxpayerPreferredLanguageID == key));
        }

        // PUT: odata/RequestTaxpayerPreferredLanguages(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestTaxpayerPreferredLanguage> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestTaxpayerPreferredLanguage requestTaxpayerPreferredLanguage = await db.RequestTaxpayerPreferredLanguages.FindAsync(key);
            if (requestTaxpayerPreferredLanguage == null)
            {
                return NotFound();
            }

            patch.Put(requestTaxpayerPreferredLanguage);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestTaxpayerPreferredLanguageExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestTaxpayerPreferredLanguage);
        }

        // POST: odata/RequestTaxpayerPreferredLanguages
        public async Task<IHttpActionResult> Post(RequestTaxpayerPreferredLanguage requestTaxpayerPreferredLanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestTaxpayerPreferredLanguages.Add(requestTaxpayerPreferredLanguage);
            await db.SaveChangesAsync();

            return Created(requestTaxpayerPreferredLanguage);
        }

        // PATCH: odata/RequestTaxpayerPreferredLanguages(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestTaxpayerPreferredLanguage> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestTaxpayerPreferredLanguage requestTaxpayerPreferredLanguage = await db.RequestTaxpayerPreferredLanguages.FindAsync(key);
            if (requestTaxpayerPreferredLanguage == null)
            {
                return NotFound();
            }

            patch.Patch(requestTaxpayerPreferredLanguage);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestTaxpayerPreferredLanguageExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestTaxpayerPreferredLanguage);
        }

        // DELETE: odata/RequestTaxpayerPreferredLanguages(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestTaxpayerPreferredLanguage requestTaxpayerPreferredLanguage = await db.RequestTaxpayerPreferredLanguages.FindAsync(key);
            if (requestTaxpayerPreferredLanguage == null)
            {
                return NotFound();
            }

            db.RequestTaxpayerPreferredLanguages.Remove(requestTaxpayerPreferredLanguage);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestTaxpayerPreferredLanguages(5)/RequestTaxpayers
        [EnableQuery]
        public IQueryable<RequestTaxpayer> GetRequestTaxpayers([FromODataUri] int key)
        {
            return db.RequestTaxpayerPreferredLanguages.Where(m => m.RequestTaxpayerPreferredLanguageID == key).SelectMany(m => m.RequestTaxpayers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestTaxpayerPreferredLanguageExists(int key)
        {
            return db.RequestTaxpayerPreferredLanguages.Count(e => e.RequestTaxpayerPreferredLanguageID == key) > 0;
        }
    }
}
