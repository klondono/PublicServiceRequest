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
using CustomerService_PSR.Utilities;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class ServiceTypeOwnerGroupsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/ServiceTypeOwnerGroups
        [EnableQuery]
        public IQueryable<ServiceTypeOwnerGroup> GetServiceTypeOwnerGroups()
        {
            //get active directory groups found in identity claims
            var UserActiveDirectoryGroup = User.Identity.GetActiveDirectoryGroups().ToArray();

            //get serviceTypes that match identity groups
            var serviceTypeOwnerGroups = (from sto in db.ServiceTypeOwnerGroups
                                where UserActiveDirectoryGroup.Contains(sto.ServiceTypeOwnerAvailableToActiveDirectoryGroupName)
                                select sto);

            return serviceTypeOwnerGroups;
        }

        // GET: odata/ServiceTypeOwnerGroups(5)
        [EnableQuery]
        public SingleResult<ServiceTypeOwnerGroup> GetServiceTypeOwnerGroup([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.ServiceTypeOwnerGroups.Where(serviceTypeOwnerGroup => serviceTypeOwnerGroup.ServiceTypeOwnerGroupID == key));
        }

        // PUT: odata/ServiceTypeOwnerGroups(5)
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<ServiceTypeOwnerGroup> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeOwnerGroup serviceTypeOwnerGroup = await db.ServiceTypeOwnerGroups.FindAsync(key);
            if (serviceTypeOwnerGroup == null)
            {
                return NotFound();
            }

            patch.Put(serviceTypeOwnerGroup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeOwnerGroupExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeOwnerGroup);
        }

        // POST: odata/ServiceTypeOwnerGroups
        public async Task<IHttpActionResult> Post(ServiceTypeOwnerGroup serviceTypeOwnerGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypeOwnerGroups.Add(serviceTypeOwnerGroup);
            await db.SaveChangesAsync();

            return Created(serviceTypeOwnerGroup);
        }

        // PATCH: odata/ServiceTypeOwnerGroups(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<ServiceTypeOwnerGroup> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceTypeOwnerGroup serviceTypeOwnerGroup = await db.ServiceTypeOwnerGroups.FindAsync(key);
            if (serviceTypeOwnerGroup == null)
            {
                return NotFound();
            }

            patch.Patch(serviceTypeOwnerGroup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeOwnerGroupExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceTypeOwnerGroup);
        }

        // DELETE: odata/ServiceTypeOwnerGroups(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceTypeOwnerGroup serviceTypeOwnerGroup = await db.ServiceTypeOwnerGroups.FindAsync(key);
            if (serviceTypeOwnerGroup == null)
            {
                return NotFound();
            }

            db.ServiceTypeOwnerGroups.Remove(serviceTypeOwnerGroup);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypeOwnerGroups(5)/ServiceTypeOwnerGroupLocation
        [EnableQuery]
        public SingleResult<ServiceTypeOwnerGroupLocation> GetServiceTypeOwnerGroupLocation([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.ServiceTypeOwnerGroups.Where(m => m.ServiceTypeOwnerGroupID == key).Select(m => m.ServiceTypeOwnerGroupLocation));
        }

        // GET: odata/ServiceTypeOwnerGroups(5)/ServiceTypes
        [EnableQuery]
        public IQueryable<ServiceType> GetServiceTypes([FromODataUri] Guid key)
        {
            return db.ServiceTypeOwnerGroups.Where(m => m.ServiceTypeOwnerGroupID == key).SelectMany(m => m.ServiceTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeOwnerGroupExists(Guid key)
        {
            return db.ServiceTypeOwnerGroups.Count(e => e.ServiceTypeOwnerGroupID == key) > 0;
        }
    }
}
