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
    public class AttachmentTypesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/AttachmentTypes
        [EnableQuery]
        public IQueryable<AttachmentType> GetAttachmentTypes()
        {
            return db.AttachmentTypes;
        }

        // GET: odata/AttachmentTypes(5)
        [EnableQuery]
        public SingleResult<AttachmentType> GetAttachmentType([FromODataUri] int key)
        {
            return SingleResult.Create(db.AttachmentTypes.Where(attachmentType => attachmentType.AttachmentTypeID == key));
        }

        // PUT: odata/AttachmentTypes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<AttachmentType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AttachmentType attachmentType = await db.AttachmentTypes.FindAsync(key);
            if (attachmentType == null)
            {
                return NotFound();
            }

            patch.Put(attachmentType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(attachmentType);
        }

        // POST: odata/AttachmentTypes
        public async Task<IHttpActionResult> Post(AttachmentType attachmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AttachmentTypes.Add(attachmentType);
            await db.SaveChangesAsync();

            return Created(attachmentType);
        }

        // PATCH: odata/AttachmentTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<AttachmentType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AttachmentType attachmentType = await db.AttachmentTypes.FindAsync(key);
            if (attachmentType == null)
            {
                return NotFound();
            }

            patch.Patch(attachmentType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(attachmentType);
        }

        // DELETE: odata/AttachmentTypes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            AttachmentType attachmentType = await db.AttachmentTypes.FindAsync(key);
            if (attachmentType == null)
            {
                return NotFound();
            }

            db.AttachmentTypes.Remove(attachmentType);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/AttachmentTypes(5)/RequestAttachments
        [EnableQuery]
        public IQueryable<RequestAttachment> GetRequestAttachments([FromODataUri] int key)
        {
            return db.AttachmentTypes.Where(m => m.AttachmentTypeID == key).SelectMany(m => m.RequestAttachments);
        }

        // GET: odata/AttachmentTypes(5)/ServiceType
        [EnableQuery]
        public SingleResult<ServiceType> GetServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.AttachmentTypes.Where(m => m.AttachmentTypeID == key).Select(m => m.ServiceType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttachmentTypeExists(int key)
        {
            return db.AttachmentTypes.Count(e => e.AttachmentTypeID == key) > 0;
        }
    }
}
