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
using MoreLinq;
using System.Web.Http.OData.Query;

namespace CustomerService_PSR.Controllers
{
    //[Authorize]
    public class View_RequestMainSearchGridWFolioController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        // GET: odata/View_RequestMainSearchGridWFolio
        [EnableQuery]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, AllowedFunctions = AllowedFunctions.All, PageSize=50, MaxSkip =50)]
        public IEnumerable<View_RequestMainSearchGridWFolio> GetView_RequestMainSearchGridWFolio(ODataQueryOptions<View_RequestMainSearchGridWFolio> options)
        {
            //WORKS BUT DOESNT ALLOW PAGING
            //var requestMainSearchGridWFolioCollection = db.View_RequestMainSearchGridWFolio;
            //var result = options.ApplyTo(db.View_RequestMainSearchGridWFolio) as IEnumerable<View_RequestMainSearchGridWFolio>;
            //return result.DistinctBy(p => p.RequestID);
            return db.View_RequestMainSearchGridWFolio;
        }

        //[EnableQuery(PageSize = 25, MaxSkip = 90, AllowedQueryOptions=AllowedQueryOptions.All,AllowedFunctions=AllowedFunctions.All)]
        ////[EnableQuery]
        //public IEnumerable<View_RequestMainSearchGridWFolio> GetView_RequestMainSearchGridWFolio(ODataQueryOptions<View_RequestMainSearchGridWFolio> options)
        //{
        //    //var validationSettings = new ODataValidationSettings
        //    //{
        //    //    AllowedQueryOptions = AllowedQueryOptions.All,
        //    //    AllowedFunctions = AllowedFunctions.All
        //    //};

        //    //options.Validate(validationSettings);

        //    IQueryable<View_RequestMainSearchGridWFolio> query = db.View_RequestMainSearchGridWFolio;
        //    var result = options.ApplyTo(query) as IEnumerable<View_RequestMainSearchGridWFolio>;

        //    //var requestMainSearchGridWFolioCollection = db.View_RequestMainSearchGridWFolio.DistinctBy(p => p.RequestID);

        //    //var resultList = new List<View_RequestMainSearchGridWFolio>();

        //    //if (options.Skip != null)
        //    //    result = result.Skip(options.Skip.Value);
        //    //if (options.Top != null)
        //    //    result = result.Take(options.Top.Value);

        //    //foreach (var item in result)
        //    //{
        //    //    if (item is View_RequestMainSearchGridWFolio)
        //    //    {
        //    //        //if(!resultList.Contains(item))
        //    //        //{
        //    //            resultList.Add((View_RequestMainSearchGridWFolio)item);
        //    //        //}

        //    //    }
        //    //    //else if (item.GetType().Name == "SelectAllAndExpand`1")
        //    //    //{
        //    //    //    var entityProperty = item.GetType().GetProperty("Instance");
        //    //    //    resultList.Add((View_RequestMainSearchGridWFolio)entityProperty.GetValue(item));
        //    //    //}
        //    //}
        //    //return resultList;
        //    return result;
        //}

        // GET: odata/View_RequestMainSearchGridWFolio(5)
        [EnableQuery]
        public SingleResult<View_RequestMainSearchGridWFolio> GetView_RequestMainSearchGridWFolio([FromODataUri] int key)
        {
            return SingleResult.Create(db.View_RequestMainSearchGridWFolio.Where(view_RequestMainSearchGridWFolio => view_RequestMainSearchGridWFolio.RequestID == key));
        }

        // PUT: odata/View_RequestMainSearchGridWFolio(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<View_RequestMainSearchGridWFolio> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_RequestMainSearchGridWFolio view_RequestMainSearchGridWFolio = await db.View_RequestMainSearchGridWFolio.FindAsync(key);
            if (view_RequestMainSearchGridWFolio == null)
            {
                return NotFound();
            }

            patch.Put(view_RequestMainSearchGridWFolio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_RequestMainSearchGridWFolioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_RequestMainSearchGridWFolio);
        }

        // POST: odata/View_RequestMainSearchGridWFolio
        public async Task<IHttpActionResult> Post(View_RequestMainSearchGridWFolio view_RequestMainSearchGridWFolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_RequestMainSearchGridWFolio.Add(view_RequestMainSearchGridWFolio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (View_RequestMainSearchGridWFolioExists(view_RequestMainSearchGridWFolio.RequestID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(view_RequestMainSearchGridWFolio);
        }

        // PATCH: odata/View_RequestMainSearchGridWFolio(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<View_RequestMainSearchGridWFolio> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            View_RequestMainSearchGridWFolio view_RequestMainSearchGridWFolio = await db.View_RequestMainSearchGridWFolio.FindAsync(key);
            if (view_RequestMainSearchGridWFolio == null)
            {
                return NotFound();
            }

            patch.Patch(view_RequestMainSearchGridWFolio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_RequestMainSearchGridWFolioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(view_RequestMainSearchGridWFolio);
        }

        // DELETE: odata/View_RequestMainSearchGridWFolio(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            View_RequestMainSearchGridWFolio view_RequestMainSearchGridWFolio = await db.View_RequestMainSearchGridWFolio.FindAsync(key);
            if (view_RequestMainSearchGridWFolio == null)
            {
                return NotFound();
            }

            db.View_RequestMainSearchGridWFolio.Remove(view_RequestMainSearchGridWFolio);
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

        private bool View_RequestMainSearchGridWFolioExists(int key)
        {
            return db.View_RequestMainSearchGridWFolio.Count(e => e.RequestID == key) > 0;
        }
    }
}
