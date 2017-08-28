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
    public class RequestAttachmentsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/RequestAttachments
        [EnableQuery]
        public IQueryable<RequestAttachment> GetRequestAttachments()
        {
            return db.RequestAttachments;
        }

        // GET: odata/RequestAttachments(5)
        [EnableQuery]
        public SingleResult<RequestAttachment> GetRequestAttachment([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestAttachments.Where(requestAttachment => requestAttachment.RequestAttachmentID == key));
        }

        // PUT: odata/RequestAttachments(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestAttachment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(key);
            if (requestAttachment == null)
            {
                return NotFound();
            }

            patch.Put(requestAttachment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestAttachmentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestAttachment);
        }

        // POST: odata/RequestAttachments
        public async Task<IHttpActionResult> Post(RequestAttachment requestAttachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestAttachments.Add(requestAttachment);
            await db.SaveChangesAsync();

            return Created(requestAttachment);
        }

        // PATCH: odata/RequestAttachments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestAttachment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(key);
            if (requestAttachment == null)
            {
                return NotFound();
            }

            patch.Patch(requestAttachment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestAttachmentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestAttachment);
        }

        // DELETE: odata/RequestAttachments(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(key);
            if (requestAttachment == null)
            {
                return NotFound();
            }

            db.RequestAttachments.Remove(requestAttachment);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestAttachments(5)/AttachmentType
        [EnableQuery]
        public SingleResult<AttachmentType> GetAttachmentType([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestAttachments.Where(m => m.RequestAttachmentID == key).Select(m => m.AttachmentType));
        }

        // GET: odata/RequestAttachments(5)/Request
        [EnableQuery]
        public SingleResult<Request> GetRequest([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestAttachments.Where(m => m.RequestAttachmentID == key).Select(m => m.Request));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestAttachmentExists(int key)
        {
            return db.RequestAttachments.Count(e => e.RequestAttachmentID == key) > 0;
        }
    }
}
