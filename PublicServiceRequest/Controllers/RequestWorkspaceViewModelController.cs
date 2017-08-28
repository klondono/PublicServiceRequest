using CustomerService_PSR.Models;
using CustomerService_PSR.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class RequestWorkspaceViewModelController : Controller
    {
        private PAGeneralDb db = new PAGeneralDb();
        private PAPortalDb PAPortaldb = new PAPortalDb();

        // GET: RequestWorkspaceViewModel
        public ActionResult GetRequestWorkspaceViewModel(int? id)
        {
            try { 
                //check if current user is authorized to view any attachments
                var ViewAttachmentsGroup = PAPortaldb.GetSystemSetting("App_CustomerService_PSR_ADGroupViewAttachment").SystemSettingValue;
                var blnViewAttachments = User.IsInActiveDirectoryGroup(ViewAttachmentsGroup);

                    //As per Lazaro, we will not make distinction between confidential of non confidential attachments
                    ////check if current user is authorized to view attachments flagged as confidential which is based on the service owner group
                    //var ViewConfidentialAttachmentsGroup = db.Database.SqlQuery<string>("SELECT [ConfidentialAttachmentGroup] = Case when OG2.ServiceTypeOwnerGroupName IS NULL THEN og.ServiceTypeOwnerActiveDirectoryGroupName ELSE og2.ServiceTypeOwnerActiveDirectoryGroupName END " +
                    //                                        "FROM [PSR].[Request] R INNER JOIN[PSR].ServiceType ST ON ST.ServiceTypeID = R.ServiceTypeID INNER JOIN[PSR].ServiceTypeOwnerGroup OG ON OG.ServiceTypeOwnerGroupID = ST.ServiceTypeOwnerGroupID "+
                    //                                        "LEFT JOIN[PSR].ServiceTypeOwnerGroup OG2 ON OG2.ServiceTypeOwnerGroupID = R.RequestCurrentOwnerGroupID "+
                    //                                        "WHERE RequestID = {0}", id).FirstOrDefault();

                    //var blnViewConfidentialAttachments = User.IsInActiveDirectoryGroup(ViewConfidentialAttachmentsGroup);
                    //return JsonNetResult class instead of json to avoid dates from being returned as millisecond number
                    return new JsonNetResult() { Data = RequestWorkspaceViewModel.GenerateRequestWorkspaceViewModel(id, db, true, blnViewAttachments) };
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "PSR Error: " + ex.Message);
            }
        }
    }
}