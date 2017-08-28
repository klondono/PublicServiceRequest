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
using System.Web.Http.OData.Query;
using CustomerService_PSR.Utilities;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class ServiceTypesController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        //Custom Methods
        // GET: odata/ServiceTypes
        [EnableQuery]
        public IQueryable<ServiceType> GetServiceTypes()
        {
            //get active directory groups found in identity claims
            var UserActiveDirectoryGroup = User.Identity.GetActiveDirectoryGroups().ToArray();

            //get serviceTypes that match identity groups
            var serviceTypes = (from st in db.ServiceTypes
                                where UserActiveDirectoryGroup.Contains(st.ServiceTypeAvailableToActiveDirectoryGroupName)
                                select st);

            return serviceTypes;
        }

        // GET: odata/ServiceTypes(5)
        [EnableQuery]
        public SingleResult<ServiceType> GetServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypes.Where(serviceType => serviceType.ServiceTypeID == key));
        }

        // PUT: odata/ServiceTypes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ServiceType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceType serviceType = await db.ServiceTypes.FindAsync(key);
            if (serviceType == null)
            {
                return NotFound();
            }

            patch.Put(serviceType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceType);
        }

        // POST: odata/ServiceTypes
        public async Task<IHttpActionResult> Post(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTypes.Add(serviceType);
            await db.SaveChangesAsync();

            return Created(serviceType);
        }

        // PATCH: odata/ServiceTypes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ServiceType> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServiceType serviceType = await db.ServiceTypes.FindAsync(key);
            if (serviceType == null)
            {
                return NotFound();
            }

            patch.Patch(serviceType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(serviceType);
        }

        // DELETE: odata/ServiceTypes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ServiceType serviceType = await db.ServiceTypes.FindAsync(key);
            if (serviceType == null)
            {
                return NotFound();
            }

            db.ServiceTypes.Remove(serviceType);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ServiceTypes(5)/AttachmentTypes
        [EnableQuery]
        public IQueryable<AttachmentType> GetAttachmentTypes([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.AttachmentTypes);
        }

        // GET: odata/ServiceTypes(5)/DefaultRequestStatusForServiceType
        [EnableQuery]
        public SingleResult<RequestStatus> GetDefaultRequestStatusForServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypes.Where(m => m.ServiceTypeID == key).Select(m => m.DefaultRequestStatusForServiceType));
        }

        // GET: odata/ServiceTypes(5)/EscalationExpectedStatusForServiceType
        [EnableQuery]
        public SingleResult<RequestStatus> GetEscalationExpectedStatusForServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypes.Where(m => m.ServiceTypeID == key).Select(m => m.EscalationExpectedStatusForServiceType));
        }

        // GET: odata/ServiceTypes(5)/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.Requests);
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeCustomFields
        [EnableQuery]
        public IQueryable<ServiceTypeCustomField> GetServiceTypeCustomFields([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeCustomFields);
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeCustomFieldTransactions
        //[EnableQuery]
        //public IQueryable<ServiceTypeCustomFieldTransaction> GetServiceTypeCustomFieldTransactions([FromODataUri] int key)
        //{
        //    return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeCustomFieldTransactions);
        //}

        // GET: odata/ServiceTypes(5)/ServiceTypeOwnerGroup
        [EnableQuery]
        public SingleResult<ServiceTypeOwnerGroup> GetServiceTypeOwnerGroup([FromODataUri] int key)
        {
            return SingleResult.Create(db.ServiceTypes.Where(m => m.ServiceTypeID == key).Select(m => m.ServiceTypeOwnerGroup));
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeRelationshipDefinitions
        [EnableQuery]
        public IQueryable<ServiceTypeRelationshipDefinition> GetServiceTypeRelationshipDefinitions([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeRelationshipDefinitions);
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeRelationshipDefinitions1
        [EnableQuery]
        public IQueryable<ServiceTypeRelationshipDefinition> GetServiceTypeRelationshipDefinitions1([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeRelationshipDefinitions1);
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeRequestActionTypeLinks
        [EnableQuery]
        public IQueryable<ServiceTypeRequestActionTypeLink> GetServiceTypeRequestActionTypeLinks([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeRequestActionTypeLinks);
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeResolutionLinks
        [EnableQuery]
        public IQueryable<ServiceTypeResolutionLink> GetServiceTypeResolutionLinks([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeResolutionLinks);
        }

        // GET: odata/ServiceTypes(5)/ServiceTypeSearchKeywordLinks
        [EnableQuery]
        public IQueryable<ServiceTypeSearchKeywordLink> GetServiceTypeSearchKeywordLinks([FromODataUri] int key)
        {
            return db.ServiceTypes.Where(m => m.ServiceTypeID == key).SelectMany(m => m.ServiceTypeSearchKeywordLinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeExists(int key)
        {
            return db.ServiceTypes.Count(e => e.ServiceTypeID == key) > 0;
        }
    }
}
