using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerService_PSR.Models;
using System.Web.Http.OData;
using System.Web.Http;

namespace PublicServiceRequest.Controllers
{
    public class PSRInterviewsController: ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();

        [EnableQuery]
        public IQueryable<PSRInterviewViewModel> GetPSRInterviews()
        {
            var query = "SELECT RF.[RequestFolioID] " +
                ",IV.[ID] as InterviewID " +
                ",R.[RequestID]" + 
                ",RF.[Folio] " +
                ",R.FormattedRequestNumber" +
                ",IV.[Year]" +
                ",IV.[Owner]" +
                ",IV.CreatedDate" +
                ",IV.FullName" +
                ",ST.ShortDescription as StatusType" +
                ",RT.LongDescription as Recommendation" +
                " FROM [PSR].[RequestFolio] RF" +
                " INNER JOIN [PSR].[InterviewValuation] IV ON RF.RequestID = IV.PSRNum AND RF.Folio = IV.Folio AND RF.Year = IV.Year " +
                " INNER JOIN [PSR].[Request] R ON R.RequestID = RF.RequestID " +
                " LEFT JOIN [PSR].[InterviewStatusType] ST ON ST.Id = IV.StatusTypeEntityId " +
                " LEFT JOIN [PSR].[InterviewRecommendationType] RT ON RT.Id = IV.RecommendationTypeEntityId ";

            return db.Database.SqlQuery<PSRInterviewViewModel>(query).AsQueryable();
        }
    }
}