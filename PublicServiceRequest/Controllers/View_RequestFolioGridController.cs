using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.Http.OData;
using CustomerService_PSR.Models;
using CustomerService_PSR.Utilities;
using System.Web.Http.OData.Query;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class View_RequestFolioGridController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();
        private CAMASQLDb camaSQLDb = new CAMASQLDb();

        // GET: odata/View_RequestFolioGrid
        [EnableQuery]
        public IQueryable<View_RequestFolioGrid> GetView_RequestFolioGrid(ODataQueryOptions opts)
        {
            IQueryable<View_RequestFolioGrid> folioList = opts.ApplyTo(db.View_RequestFolioGrid.AsQueryable()) as IQueryable<View_RequestFolioGrid>;

            //if user does not have permission to view confidential folios check current confidential status for real prop folios
            if (!User.IsInActiveDirectoryGroup("(PA) AS_PSR_SecG_View_Confidential"))
            {
                bool isConfidential = false;
                foreach (var folio in folioList)
                {
                    folio.UserCanViewConfidential = false;
                    folio.ConfidentialAtTimeOfRequestFlag = false;

                    if (folio.RequestFolioTypeID == 1)
                    {
                        isConfidential = camaSQLDb.GetParcelData(folio.Folio).ConfidentialFlag == "Y";
                        if (isConfidential)
                        {
                            folio.SiteAddress = "";
                            folio.Owner = "";
                            folio.ConfidentialAtTimeOfRequestFlag = true;
                        }
                    }
                }
            }
            return folioList;
        }

        // GET: odata/View_RequestFolioGrid(5)
        [EnableQuery]
        public SingleResult<View_RequestFolioGrid> GetView_RequestFolioGrid([FromODataUri] int key)
        {
            return SingleResult.Create(db.View_RequestFolioGrid.Where(view_RequestFolioGrid => view_RequestFolioGrid.RequestFolioID == key));
        }

        // PUT: odata/View_RequestFolioGrid(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<View_RequestFolioGrid> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_RequestFolioGrid view_RequestFolioGrid = db.View_RequestFolioGrid.Find(key);
            if (view_RequestFolioGrid == null)
            {
                return NotFound();
            }

            patch.Put(view_RequestFolioGrid);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_RequestFolioGridExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_RequestFolioGrid);
        }

        // POST: odata/View_RequestFolioGrid
        public IHttpActionResult Post(View_RequestFolioGrid view_RequestFolioGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_RequestFolioGrid.Add(view_RequestFolioGrid);
            db.SaveChanges();

            return Created(view_RequestFolioGrid);
        }

        // PATCH: odata/View_RequestFolioGrid(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<View_RequestFolioGrid> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_RequestFolioGrid view_RequestFolioGrid = db.View_RequestFolioGrid.Find(key);
            if (view_RequestFolioGrid == null)
            {
                return NotFound();
            }

            patch.Patch(view_RequestFolioGrid);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_RequestFolioGridExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_RequestFolioGrid);
        }

        // DELETE: odata/View_RequestFolioGrid(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            View_RequestFolioGrid view_RequestFolioGrid = db.View_RequestFolioGrid.Find(key);
            if (view_RequestFolioGrid == null)
            {
                return NotFound();
            }

            db.View_RequestFolioGrid.Remove(view_RequestFolioGrid);
            db.SaveChanges();

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

        private bool View_RequestFolioGridExists(int key)
        {
            return db.View_RequestFolioGrid.Count(e => e.RequestFolioID == key) > 0;
        }
    }
}
