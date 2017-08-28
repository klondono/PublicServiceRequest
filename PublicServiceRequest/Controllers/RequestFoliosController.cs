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
    public class RequestFoliosController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();
        private CAMASQLDb dbCAMA = new CAMASQLDb();

        #region custom odata methods
        [HttpPost]
        public RequestFolioViewModel ValidateFolio(ODataActionParameters parameters)
            {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            //assign the odata method parameter to variable
            var strFolioNo = parameters["FolioNo"] as string;
            var strPropertyType = parameters["PropertyType"] as string;
            var strYear = parameters["Year"] as string;

            //Per Jose: regardless of year parameter, current business rule requires validating against current year; However, the year parameter is added as part of validated folio returned to user
            //var strHistoryRunID = strYear + "09";

            if (strPropertyType.Trim() == "Real Property Folio")
            {
                ParcelData parcelData = new ParcelData();
                parcelData = dbCAMA.GetParcelData(strFolioNo);

                if (parcelData != null)
                {
                    var requestFolio = new RequestFolioViewModel
                    {
                        RequestFolioTypeID = 1,//Real Property
                        FormattedFolio = RequestUtilities.FormatFolio(parcelData.Strap),
                        Folio = parcelData.Strap,
                        District = parcelData.District,
                        SiteAddress = parcelData.TrueSiteAddress,
                        SiteCity = parcelData.TrueSiteCity,
                        ZipCode = parcelData.TrueSiteZipCode,
                        HistoryRunID = parcelData.HistoryRunID,
                        DORCode = parcelData.DORCodeCurrent,
                        Owner = parcelData.TrueOwner1,
                        Year = Convert.ToInt16(strYear),// parcelData.AssessmentYearCurrent
                        Cancelled = parcelData.CancelFlag,
                        Confidential = parcelData.ConfidentialFlag                        
                    };


                    requestFolio.HasOpenPSR = (from rf in db.RequestFolios
                              join r in db.Requests on rf.RequestID equals r.RequestParentRootID
                              join r1 in db.Requests on r.RequestID equals r1.RequestID
                              where r1.RequestCompletionDate == null && rf.Folio == requestFolio.Folio
                              select r.RequestID).Any();
                                              
                    return requestFolio;
                }
                return null;
            }
            else
            {
                var strHistoryRunID = dbCAMA.GetCurrentRollYear().ToString() + "09";
                var intHistoryRunID = Convert.ToInt32(strHistoryRunID);
                var tangiblePropData = db.View_PersonalPropertyData.Where(x => x.HistoryRunID == intHistoryRunID && x.Folio == strFolioNo).FirstOrDefault();

                if (tangiblePropData != null)
                {
                    var requestTPPFolio = new RequestFolioViewModel
                    {
                        RequestFolioTypeID = 2,//Personal Property
                        FormattedFolio = tangiblePropData.FormattedFolio,
                        Folio = tangiblePropData.Folio,
                        District = null,
                        SiteAddress = tangiblePropData.SiteAddress,
                        SiteCity = null,
                        ZipCode = tangiblePropData.ZipCode,
                        HistoryRunID = tangiblePropData.HistoryRunID,
                        DORCode = tangiblePropData.DORCode.ToString(),
                        Owner = tangiblePropData.Owner,
                        Year = Convert.ToInt16(strYear),//Convert.ToInt16(tangiblePropData.Year)
                        Cancelled = tangiblePropData.Cancelled,
                        Confidential = tangiblePropData.Confidential
                    };

                    requestTPPFolio.HasOpenPSR = db.RequestFolios.Include(p => p.Request).Where(x => x.Request.RequestCompletionDate == null && x.Folio == requestTPPFolio.Folio).Any();

                    return requestTPPFolio;
                }
                return null;
            }
        }

        [HttpPost]
        public List<RequestFolioAlertModalViewModel> GetOpenRequestsByFolio(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            //assign the odata method parameter to variable
            var strFolioNo = parameters["FolioNo"] as string;

            var strQuery = "SELECT R.RequestID, RT.FormattedTaxpayerName, R.AdmUserAddedFullName, R.AdmDateAdded, R.RequestCurrentWorkerFullName, R.FormattedRequestNumber, R.RequestComments, ST.ServiceTypeName, RS.RequestStatusName, RS.RequestStatusColor "+
            "FROM [PSR].RequestFolio RF INNER JOIN "+
            "[PSR].Request R1 ON R1.RequestParentRootID = RF.RequestID INNER JOIN " +
            "[PSR].Request R ON R.RequestID = R1.RequestID INNER JOIN " +
            "[PSR].ServiceType ST ON R.ServiceTypeID = ST.ServiceTypeID INNER JOIN " +
            "[PSR].RequestStatus RS ON R.RequestStatusID = RS.RequestStatusID LEFT JOIN " +
            "[PSR].RequestTaxpayer RT ON R.RequestTaxpayerID = RT.RequestTaxpayerID " +
            $"WHERE RF.Folio = '{strFolioNo}' AND R.RequestCompletionDate IS NULL";

            return db.Database.SqlQuery<RequestFolioAlertModalViewModel>(strQuery).ToList();
        }

        #endregion custom odata methods

            // GET: odata/RequestFolios
        [EnableQuery]
        public IQueryable<RequestFolio> GetRequestFolios()
        {
            return db.RequestFolios;
        }

        // GET: odata/RequestFolios(5)
        [EnableQuery]
        public SingleResult<RequestFolio> GetRequestFolio([FromODataUri] int key)
        {


            return SingleResult.Create(db.RequestFolios.Where(requestFolio => requestFolio.RequestFolioID == key));
        }

        // PUT: odata/RequestFolios(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<RequestFolio> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestFolio requestFolio = await db.RequestFolios.FindAsync(key);
            if (requestFolio == null)
            {
                return NotFound();
            }

            patch.Put(requestFolio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestFolioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestFolio);
        }

        // POST: odata/RequestFolios
        public async Task<IHttpActionResult> Post(RequestFolio requestFolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestFolios.Add(requestFolio);
            await db.SaveChangesAsync();

            return Created(requestFolio);
        }

        // PATCH: odata/RequestFolios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<RequestFolio> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RequestFolio requestFolio = await db.RequestFolios.FindAsync(key);
            if (requestFolio == null)
            {
                return NotFound();
            }

            patch.Patch(requestFolio);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestFolioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(requestFolio);
        }

        // DELETE: odata/RequestFolios(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            RequestFolio requestFolio = await db.RequestFolios.FindAsync(key);
            if (requestFolio == null)
            {
                return NotFound();
            }

            db.RequestFolios.Remove(requestFolio);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/RequestFolios(5)/Request
        [EnableQuery]
        public SingleResult<Request> GetRequest([FromODataUri] int key)
        {
            return SingleResult.Create(db.RequestFolios.Where(m => m.RequestFolioID == key).Select(m => m.Request));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestFolioExists(int key)
        {
            return db.RequestFolios.Count(e => e.RequestFolioID == key) > 0;
        }
    }
}
