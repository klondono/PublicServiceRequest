using CustomerService_PSR.Models;
using CustomerService_PSR.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerService_PSR.Controllers
{
    public class MyDashboardController : Controller
    {
        private PAGeneralDb db = new PAGeneralDb();
        private PAPortalDb portalDb = new PAPortalDb();
        // GET: Dashboard
        [HttpGet]
        public ActionResult GetMyDashboardViewModel()
        {
            var userID = User.Identity.GetUserID();

            var dashboardViewModel = new MyDashboardViewModel();

            var initialResponseTimeInHours = portalDb.GetSystemSetting("App_CustomerService_PSR_FirstActionGracePeriod").SystemSettingValue;
            var followUpIntervalInHours = portalDb.GetSystemSetting("App_CustomerService_PSR_ActionIntervalLimit").SystemSettingValue;

            dashboardViewModel.StatOne = GetNewRequestAssignmentCountForUser(userID, initialResponseTimeInHours);
            dashboardViewModel.StatTwo = GetNonNewRequestAssignmentCountForUser(userID);
            dashboardViewModel.StatThree = GetResponseOverdueRequestsForUser(userID, initialResponseTimeInHours);
            dashboardViewModel.StatFour = GetFollowUpOverdueRequestsForUser(userID, followUpIntervalInHours);

            //return JsonNetResult class instead of json to avoid dates from being returned as millisecond number
            return new JsonNetResult() { Data = dashboardViewModel };
        }

        private int GetNewRequestAssignmentCountForUser(Guid? userID, string initialResponseTimeInHours)
        {
            var newCountQuery = "SELECT COUNT(*)  FROM [PSR].[Request] R WHERE " +
                                $"R.AdmIsActive = 'Y' AND R.RequestCompletionDate IS NULL AND R.RequestCurrentWorkerID = '{userID}' AND R.RequestStatusID = 1 AND DATEDIFF(hh,R.AdmDateAdded,GETDATE()) < {initialResponseTimeInHours} ";
            return db.Database.SqlQuery<int>(newCountQuery).FirstOrDefault();
        }

        private int GetNonNewRequestAssignmentCountForUser(Guid? userID)
        {
            var pendingCountQuery = "SELECT COUNT(*) FROM [PSR].[Request] R INNER JOIN " +
                                    "[PSR].[RequestAction] RA1 ON RA1.RequestID = R.RequestID INNER JOIN ( " +
                                    "SELECT MAX(RequestActionID) as maxRequestActionID, RA.RequestID, RA.RequestAssignedUserID " +
                                    "FROM [PSR].[RequestAction] RA " +
                                    "INNER JOIN [PSR].[Request] R ON RA.RequestID = R.RequestID AND RA.RequestAssignedUserID = R.RequestCurrentWorkerID " +
                                    $"WHERE RA.AdmIsActive = 'Y' AND R.AdmIsActive = 'Y' AND R.RequestCompletionDate IS NULL AND RA.RequestAssignedUserID = '{userID}' " +
                                    "Group By RA.RequestID, RA.RequestAssignedUserID " +
                                    ") MaxAssignment ON MaxAssignment.maxRequestActionID = RA1.RequestActionID " +
                                    "WHERE NOT EXISTS " +
                                    "(SELECT RequestActionID FROM [PSR].[RequestAction] RA2 WHERE RA2.AdmIsActive = 'Y' AND RA2.RequestID = RA1.RequestID AND RA2.RequestActionID > maxRequestActionID) " +
                                    "AND R.RequestStatusID <> 1 ";

            return db.Database.SqlQuery<int>(pendingCountQuery).FirstOrDefault();
        }

        private int GetResponseOverdueRequestsForUser(Guid? userID, string initialResponseTimeInHours)
        {
            var responseOverdueQuery = "SELECT COUNT(*) FROM [PSR].[Request] R WHERE " +
                                        $"R.AdmIsActive = 'Y' AND R.RequestCompletionDate IS NULL AND R.RequestCurrentWorkerID = '{userID}' AND R.RequestStatusID = 1 AND DATEDIFF(hh,R.AdmDateAdded,GETDATE()) >= {initialResponseTimeInHours}";

            return db.Database.SqlQuery<int>(responseOverdueQuery).FirstOrDefault();
        }

        private int GetFollowUpOverdueRequestsForUser(Guid? userID, string followUpIntervalInHours)
        {
            var followUpCountQuery = "SELECT COUNT(*) FROM [PSR].[Request] R " +
                                        "LEFT JOIN (SELECT RequestID, RequestActionID, AdmDateAdded FROM [PSR].[RequestAction]) RA ON R.RequestID = RA.RequestID " +
                                        "INNER JOIN (SELECT RA1.RequestID, MAX(RA1.RequestActionID) as maxRequestActionID FROM [PSR].[RequestAction] RA1 " +
                                        "WHERE RA1.AdmIsActive = 'Y' GROUP BY RA1.RequestID) MAXACTION ON MAXACTION.maxRequestActionID = RA.RequestActionID " +
                                        $"WHERE R.RequestCurrentWorkerID = '{userID}' AND R.AdmIsActive = 'Y' AND R.RequestCompletionDate IS NULL AND R.RequestStatusID <> 1 AND DATEDIFF(hh, RA.AdmDateAdded, GETDATE()) > {followUpIntervalInHours} ";

            return db.Database.SqlQuery<int>(followUpCountQuery).FirstOrDefault();
        }

    }
}