using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public static class PSRCustomizations
    {
        public static void ExecuteOnRequestGeneration(int requestID, int? ServiceTypeID, PAGeneralDb db)
        {
            //if service type is 'Homestead Fraud' create a new lead in Investigations database
            if (ServiceTypeID == 43)
            {
                CreateInvestigationsLead(requestID, db);
            }
        }

        public static void ExecuteOnRequestReassignment(int requestID, string serviceTypeOwnerGroupID, PAGeneralDb db)
        {
            //if PSR is reassigned to 'Investigations' create a new lead in Investigations database if it does not already exist
            if (String.Equals(serviceTypeOwnerGroupID, "2D0CCD92-D30A-4182-96F0-0EDDCB3A39CA", StringComparison.OrdinalIgnoreCase))
            {
                CreateInvestigationsLead(requestID, db);
            }
        }

        public static bool ByPassPrecedenceConstraint(int count, string[] arrRequestActionTypeIDs, int? taxpayerID)
        {
            //if action type constraint to be satisfied is 'Initial Customer Contact' but the customer is anonymous, bypass constraint
            if (count == 1 && arrRequestActionTypeIDs.Contains("10") && taxpayerID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool ContainsFolios(int RequestID, PAGeneralDb db)
        {
            return db.RequestFolios.Where(x => x.RequestID == RequestID).Any();
        }

        private static void CreateInvestigationsLead(int RequestID, PAGeneralDb db)
        {
            if (ContainsFolios(RequestID, db))
            {
                var strInsertInvestigationsLeadDetail = "INSERT INTO [PAInvestigation].[dbo].[LeadDetail] " +
                    "([LeadFolio],[LeadDate],[LeadSourceID],[LeadReasonID],[LeadStatusID],[RelatedPSRNum],[RelatedFormattedPSRNum],[ContactName],[ContactPhone],[ContactEmail],[AdmLeadDateCreated],[AdmLeadCreatedUID],[ContactComments]) " +
                    "SELECT ISNULL(TOPFOLIO.Folio,0), R.AdmDateAdded, 11, 33, 5, R.RequestID, R.FormattedRequestNumber, RT.FormattedTaxpayerName, RT.PhoneNo, RT.Email, GetDate(), 'PSRImport', R.RequestComments " +
                    "FROM [PSR].Request R " +
                    "LEFT JOIN [PSR].RequestTaxpayer RT ON RT.RequestTaxpayerID = R.RequestTaxpayerID " +
                    "OUTER APPLY (SELECT TOP 1 RF.Folio FROM [PSR].RequestFolio RF WHERE RF.RequestID = R.RequestID ORDER BY RF.RequestFolioID) AS TOPFOLIO " +
                    "WHERE R.RequestID = @RequestID AND NOT EXISTS (SELECT LD2.RelatedPSRNum FROM [PAInvestigation].[dbo].[LeadDetail] LD2 WHERE LD2.RelatedPSRNum = R.RequestID) ";

                var strInsertInvestigationsComments = "INSERT INTO [PAInvestigation].[dbo].[InvComments] " +
                                "([Folio], [StaffID], [CommentDate], [LeadID], [CommentTypeID], [CommentText]) " +
                                "SELECT LD.LeadFolio, 'PSRImport', LD.AdmLeadDateCreated, LD.LeadID, 1, 'PSR: ' + ISNULL(LD.RelatedFormattedPSRNum,'No PSR Number') + ', Phone/email: ' + ISNULL(LD.ContactPhone,' None') + ', CommentText: ' + ISNULL(LD.ContactComments, ' None') " +
                                "FROM [PAInvestigation].[dbo].LeadDetail LD " +
                                "WHERE LD.RelatedPSRNum = @RequestID AND NOT EXISTS(SELECT IC.LeadID FROM[PAInvestigation].[dbo].[InvComments] IC WHERE IC.LeadID = LD.LeadID)";

                db.Database.ExecuteSqlCommand(strInsertInvestigationsLeadDetail + strInsertInvestigationsComments,
                    new SqlParameter("@RequestID", RequestID));
            }
        }
    }
}