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
using System.Web;
using System.Web.Http.OData.Query;
using System.Globalization;
using CustomerService_PSR.Utilities;
using System.Data.SqlClient;
using System.Threading;
using MoreLinq;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class RequestsController : ODataController
    {
        private PAGeneralDb db = new PAGeneralDb();
        private CAMASQLDb dbCAMA = new CAMASQLDb();
        private PAPortalDb PAPortaldb = new PAPortalDb();
        #region custom odata methods
        public RequestCreateViewModel InitializeRequest(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var key = parameters["ServiceTypeID"] as int?;
            RequestCreateViewModel newRequest = new RequestCreateViewModel();
            RequestInit(newRequest, key);
            return newRequest;
        }

        public RequestMainSearchViewModel InitializeRequestMainSearch()
        {
            RequestMainSearchViewModel newRequestMainSearch = new RequestMainSearchViewModel();

            newRequestMainSearch.RequestNo = "";
            newRequestMainSearch.Folio = "";
            newRequestMainSearch.Requestor = "";
            newRequestMainSearch.CreatedFrom = "";
            newRequestMainSearch.CreatedTo = "";

            newRequestMainSearch.StatusList = new List<SearchStatusViewModel>();
            newRequestMainSearch.StatusList.Add(new SearchStatusViewModel { StatusValue = 0, StatusName = "- All -" });
            newRequestMainSearch.StatusList.Add(new SearchStatusViewModel { StatusValue = 1, StatusName = "Open" });
            newRequestMainSearch.StatusList.Add(new SearchStatusViewModel { StatusValue = 2, StatusName = "Closed" });
            //newRequestMainSearch.StatusList.Add(new SearchStatusViewModel { StatusValue = 3, StatusName = "Overdue" });
            //newRequestMainSearch.StatusList.Add(new SearchStatusViewModel { StatusValue = 4, StatusName = "Open or Cancelled" });

            newRequestMainSearch.AssigneeList = new List<SearchAssigneeViewModel>();
            //add select list option for all
            newRequestMainSearch.AssigneeList.Add(new SearchAssigneeViewModel { AssigneeID = new Guid(), AssigneeName = "- All -", AssigneeType = "", AssigneeUniqueID = "0" });

            var ownerGroups = db.ServiceTypeOwnerGroups.Where(x=>x.SelectableOnRequestCreationFlag == true || x.SelectableOnRequestReassignmentFlag == true).Select(x => new { x.ServiceTypeOwnerGroupName, x.ServiceTypeOwnerGroupID }).OrderBy(x => x.ServiceTypeOwnerGroupName);
            foreach (var group in ownerGroups)
            {
                newRequestMainSearch.AssigneeList.Add(new SearchAssigneeViewModel
                {
                    AssigneeID = group.ServiceTypeOwnerGroupID,
                    AssigneeName = group.ServiceTypeOwnerGroupName,
                    AssigneeType = "Business Area",
                    AssigneeUniqueID = "22" + group.ServiceTypeOwnerGroupID//prefix id with 22 to distinguish groupid from userid for use in angular select list  
                });
            }

            var users = db.Users.Where(x=>x.FullName != "Application" && x.FullName != null).Select(x => new { x.FullName, x.Id }).ToList().OrderBy(x => x.FullName);
            foreach (var user in users)
            {
                newRequestMainSearch.AssigneeList.Add(new SearchAssigneeViewModel
                {
                    AssigneeID = user.Id,
                    AssigneeName = user.FullName,
                    AssigneeType = "Users",
                    AssigneeUniqueID = "11" + user.Id//prefix id with 11 to distinguish userid from groupid for use in angular select list
                });
            }

            //set default parameters
            var guidCurrentUserID = User.Identity.GetUserID();
            var userFullName = users.Where(x => x.Id == guidCurrentUserID).Select(x => x.FullName).FirstOrDefault();
            //getting full name from identity since logged user may not have record in app users table
            newRequestMainSearch.CurrentUser = User.Identity.GetFullName();
            newRequestMainSearch.SelectedStatusID = 1;
            newRequestMainSearch.SelectedAssignee = new SearchAssigneeViewModel
            {
                AssigneeID = guidCurrentUserID,
                AssigneeName = userFullName,
                AssigneeType = "Users",
                AssigneeUniqueID = "11" + guidCurrentUserID//prefix id with 11 to distinguish userid from groupid for use in angular select list
            };

            return newRequestMainSearch;
        }

        [HttpPost]
        public IHttpActionResult GetRequestWorkspaceViewModel(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var key = parameters["RequestID"] as int?;

            try
            {
                //check if current user is authorized to view any attachments
                var ViewAttachmentsGroup = PAPortaldb.GetSystemSetting("App_CustomerService_PSR_ADGroupViewAttachment").SystemSettingValue;
                var blnViewAttachments = User.IsInActiveDirectoryGroup(ViewAttachmentsGroup);

                //As per Lazaro, we will not make distinction between confidential of non confidential attachments
                ////check if current user is authorized to view attachments flagged as confidential which is based on the service owner group
                //var ViewConfidentialAttachmentsGroup = db.Database.SqlQuery<string>("SELECT [ConfidentialAttachmentGroup] = Case when OG2.ServiceTypeOwnerGroupName IS NULL THEN og.ServiceTypeOwnerActiveDirectoryGroupName ELSE og2.ServiceTypeOwnerActiveDirectoryGroupName END " +
                //                                        "FROM [PSR].[Request] R INNER JOIN[PSR].ServiceType ST ON ST.ServiceTypeID = R.ServiceTypeID INNER JOIN[PSR].ServiceTypeOwnerGroup OG ON OG.ServiceTypeOwnerGroupID = ST.ServiceTypeOwnerGroupID " +
                //                                        "LEFT JOIN[PSR].ServiceTypeOwnerGroup OG2 ON OG2.ServiceTypeOwnerGroupID = R.RequestCurrentOwnerGroupID " +
                //                                        "WHERE RequestID = {0}", key).FirstOrDefault();

                //var blnViewConfidentialAttachments = User.IsInActiveDirectoryGroup(ViewConfidentialAttachmentsGroup);

                return Content(HttpStatusCode.OK,RequestWorkspaceViewModel.GenerateRequestWorkspaceViewModel(key, db, true, blnViewAttachments));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PSR Error " + ex.Message, ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateRequest(ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                //assign the 2 odata method parameters to variables
                var newPSR = parameters["NewRequest"] as RequestCreateViewModel;
                var associatedRequestContainer = parameters["AssociatedServiceTypes"] as AssociatedServiceTypeContainerViewModel;

                //determine if request includes taxpayer info
                bool blnAddNewTaxpayer = newPSR.RequestTaxpayerInfo.RequestTaxpayerID == 0 && newPSR.RequestTaxpayerInfo.RemainAnonymousFlag == false;
                bool attachmentsIncluded = newPSR.RequestAttachments.Count > 0;

                //Parent-child relationships, effective dates and due dates are already calculated for the AssociatedServiceTypes (tvf GetServiceTypeChildrenByParent in the db).  
                //However, AssociatedServiceTypes that have their ServiceTypeChildCheckedByDefaultFlag set to false because the service type was unchecked by the user
                //are going to be excluded but they may have had dependant children requests that are now 'orphaned'.
                //this method reassigns the orphan's ServiceTypeParentID, and adjusts the Effective Date, Due Date, etc. 
                //relative to the next 'active' parent in the hierarchy ('active' = ServiceTypeChildCheckedByDefaultFlag set to true) 
                ConnectOrphanedRequests(associatedRequestContainer.AssociatedServiceTypes);

                //get only ServiceTypes that have their ServiceTypeChildCheckedByDefaultFlag set to true before saving but AFTER connecting orphaned requests
                var associatedServiceTypes = associatedRequestContainer.AssociatedServiceTypes.Where(x => x.ServiceTypeChildCheckedByDefaultFlag == true).ToList();

                //get custom fields => (custom fields for ServiceTypes that have their ServiceTypeChildCheckedByDefaultFlag set to false have already been excluded on the client side
                var customFields = associatedRequestContainer.CustomFields;

                //determine whether all child/dependant requests are to be generated at once based on ServiceTypeConcurrentCreationOfChildrenFlag property of root parent request
                //if false, only the root parent request is created as well as any requests that are defined to start immediately with the parent (that is, their ServiceTypeChildStartTriggerID is set to 1)
                bool generateChildRequests = associatedServiceTypes.FirstOrDefault(x => x.ServiceTypeParentID == 0).ServiceTypeConcurrentCreationOfChildrenFlag;

                List<Request> newRequests = new List<Request>();
                //Generate Request Number and other pertinent info
                var requestNumber = GenerateRequestNumber(GetLastRequestNumber());
                var dtNow = DateTime.Now;
                var requestYear = (short)dtNow.Year;
                //for each service type in associatedServiceTypes, generate new Request in memory
                for (var counter = 0; counter < associatedServiceTypes.Count(); counter++)
                {
                    //get service type
                    var serviceType = associatedServiceTypes.ElementAt(counter);
                    //get district no from first folio that has one
                    int? districtNo = newPSR.FolioList.Where(x => x.District != null).Select(x => x.District).FirstOrDefault();
                    //add request
                    newRequests.Add(GenerateRequest(newPSR, serviceType, requestNumber, requestYear, counter, associatedServiceTypes.Count(), districtNo, newPSR.RequestTaxpayerInfo.RemainAnonymousFlag, customFields, generateChildRequests, dtNow, attachmentsIncluded));
                }
                List<Request> requestsToBeAdded = null;

                //if generateChildRequests is false, then requestsToBeAdded will include all requests whose effective date is today
                if (!generateChildRequests)
                {
                    requestsToBeAdded = newRequests.Where(x => x.AdjustedRequestEffectiveDate.Value.Date == DateTime.Now.Date).ToList();
                }
                //otherwise generate all requests
                else requestsToBeAdded = newRequests;

                //if request includes taxpayer info, add new RequestTaxpayer to context first then assign requests to that taxpayer
                if (blnAddNewTaxpayer)
                {
                    var requestTaxpayer = AddTaxpayer(newPSR);
                    requestTaxpayer.Requests = requestsToBeAdded;
                }
                //otherwise add requests directly to requests db set
                else
                {
                    db.Requests.AddRange(requestsToBeAdded);
                }

                //Prevent duplicate request number generation, loop until unique FormattedRequestNumber is ensured
                var addedUniqueRequestNumber = false;
                while (!addedUniqueRequestNumber) 
                {
                    try
                    {
                        //execute save
                        db.SaveChanges();
                        addedUniqueRequestNumber = true;
                    }
                    catch (Exception ex)
                    {
                        var innerException = ex.FromHierarchy(x => x.InnerException).Select(x => x.InnerException);
                        dynamic innerMostException = innerException.Where(x => x.InnerException == null).FirstOrDefault();
                        if (innerMostException is SqlException)
                        {
                            //code for invalid duplicate key value for db constraint on FormattedCaseNumber
                            if (innerMostException.Number == 2627)
                            {
                                var newCaseNumber = Convert.ToInt32(requestNumber);
                                requestNumber = GenerateRequestNumber(newCaseNumber++.ToString());
                                newRequests.ForEach(x => x.RequestNumber = requestNumber);
                                requestsToBeAdded.ForEach(x => x.RequestNumber = requestNumber);
                            }
                        }
                        else
                        {
                            throw new Exception("Error on create db.SaveChanges(): " + ex.ToString());
                        }
                    }
                }

                //get root parent request id & requesttaxpayerid
                var newParentRootRequest = newRequests.Where(x => x.RequestImmediateParentID == 0).Select(x => new { x.RequestID, x.RequestTaxpayerID }).FirstOrDefault();

                //updates the request table in the database and 
                //captures the relationships among associated and dependant requests at the time that they were generated 
                //(replaces ServiceTypeID of parent with actual parent request id that was generated; 
                //This is necessary for the shifting of effective and due dates as requests get closed earlier or later than due date
                CustomerService_PSR.Models.Request.SetRequestRelationships(requestYear, requestNumber, db);

                //if request includes attachments, these attachments were included as part of a request action, 
                //therefore statement below updates the attachment's request id with the generated requestid using the parent root request id as parameter
                if (attachmentsIncluded)
                {
                    db.Database.ExecuteSqlCommand("UPDATE [PSR].[RequestAttachment] SET RequestID = R.RequestID FROM [PSR].[RequestAttachment] RAT " +
                            "INNER JOIN [PSR].[RequestAction] RA ON RAT.RequestActionID = RA.RequestActionID " +
                            "INNER JOIN [PSR].[Request] R ON R.RequestID = RA.RequestID WHERE R.RequestParentRootID = @ParentRootRequest",
                            new SqlParameter("@ParentRootRequest", newParentRootRequest.RequestID));
                }

                //Create request queue records for requests that were deferred and will be created as each parent request is closed in the future
                SendDeferredRequestsToRequestQueue(newRequests, requestsToBeAdded, newParentRootRequest.RequestID, newParentRootRequest.RequestTaxpayerID);

                //Execute custom logic
                PSRCustomizations.ExecuteOnRequestGeneration(newParentRootRequest.RequestID, newPSR.ServiceTypeID, db);

                //if not in PROD environment don't send email
                if (Environment.GetEnvironmentVariable("PAENVIRONMENT") != null)
                {
                    var userName = User.Identity.GetFullName();
                    var email = User.Identity.GetEmail();
                    //Send email -- start new task so that this method does not have to wait for send email to complete
                    Task sendEmail = Task.Factory.StartNew(() =>
                    {
                        RequestUtilities.SendRequestSystemEmail(GetGeneratedRequests(requestNumber, requestYear, userName, email), "New");
                    });
                }

                return Ok<int>(newParentRootRequest.RequestID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PSR Create Error", ex);
                return BadRequest(ModelState);
            }
        }

        #endregion custom odata methods

        #region auxilliary methods
        private void ConnectOrphanedRequests(List<AssociatedServiceTypeViewModel> associatedServiceTypes)
        {
            //get id of deadbeat parents who left their children orhpaned
            var excludedParentRequests = associatedServiceTypes.Where(x => x.ServiceTypeChildCheckedByDefaultFlag == false).Select(x => x.ServiceTypeID).ToArray();
            //get orhpaned requests that do NOT have their ServiceTypeChildCheckedByDefaultFlag set to false 
            //and order by tree level, i.e. requests that are higher in the parent hierarchy evaluated first
            var orphanedRequests = associatedServiceTypes.Where(x => excludedParentRequests.Contains(x.ServiceTypeParentID) && x.ServiceTypeChildCheckedByDefaultFlag != false).OrderBy(x => x.TreeLevel);

            foreach (var orphan in orphanedRequests)
            {
                //parent is deadbeat, let me see if my grandpa can adopt me
                var grandParentID = associatedServiceTypes.FirstOrDefault(x => x.ServiceTypeID == orphan.ServiceTypeParentID).ServiceTypeParentID;
                var grandParent = associatedServiceTypes.FirstOrDefault(x => x.ServiceTypeID == grandParentID);
                ConnectWithNextActiveParentInHierarchy(orphan, grandParent, associatedServiceTypes);
            }
        }

        private void ConnectWithNextActiveParentInHierarchy(AssociatedServiceTypeViewModel child, AssociatedServiceTypeViewModel grandParent, List<AssociatedServiceTypeViewModel> associatedServiceTypes)
        {
            if (grandParent.ServiceTypeChildCheckedByDefaultFlag == true)
            {
                child.ServiceTypeParentID = grandParent.ServiceTypeID;
                child.ServiceTypeParentName = grandParent.ServiceTypeName;

                //if ServiceTypeChildStartTriggerID = 1, then child is starts with parent plus any delay time specified
                if (child.ServiceTypeChildStartTriggerID == 1 || grandParent.ServiceTypeParentClosesWhenChildrenClosedFlag == true)
                {
                    child.EffectiveDate = grandParent.EffectiveDate.Value.AddDays(Convert.ToDouble(child.ServiceTypeChildStartDelay));
                }
                //otherwise, child starts AFTER parent plus any delay time specified
                else
                {
                    child.EffectiveDate = grandParent.DueDate.Value.AddDays(Convert.ToDouble(child.ServiceTypeChildStartDelay));
                }
                //set due date based on specified duration after effective date
                child.DueDate = child.EffectiveDate.Value.AddDays(Convert.ToDouble(child.ServiceTypeChildDuration));
                return;
            }
            else
            {
                var newGrandParent = associatedServiceTypes.FirstOrDefault(x => x.ServiceTypeID == grandParent.ServiceTypeParentID);
                ConnectWithNextActiveParentInHierarchy(child, newGrandParent, associatedServiceTypes);
            }
        }

        private void SendDeferredRequestsToRequestQueue(List<Request> newRequests, List<Request> requestsToBeAdded, int rootRequestID, int? requestTaxpayerID)
        {
            List<Request> deferredRequests = newRequests.Except(requestsToBeAdded).ToList();           

            if(deferredRequests.Any())
            {
                List<RequestQueue> requestQueues = new List<RequestQueue>();

                deferredRequests.ForEach(x => requestQueues.Add(new RequestQueue {
                    ServiceTypeID = x.ServiceTypeID,
                    RequestImmediateParentID = x.RequestImmediateParentID,
                    RequestParentRootID = rootRequestID,
                    RequestStatusID = x.RequestStatusID,
                    RequestStartTrigger = x.RequestStartTrigger,
                    RequestYear = x.RequestYear,
                    RequestNumber = x.RequestNumber,
                    RequestSuffix = x.RequestSuffix,
                    RequestStartDelayDefinition = x.RequestStartDelayDefinition,
                    RequestDurationDefinition = x.RequestDurationDefinition,
                    RequestEscalationExpectedStatusID = x.RequestEscalationExpectedStatusID,
                    RequestChildrenCloseParentFlag = x.RequestChildrenCloseParentFlag,
                    RequestCurrentWorkerID = x.RequestCurrentWorkerID,
                    RequestCurrentOwnerGroupID = x.RequestCurrentOwnerGroupID,
                    RequestCurrentWorkerFullName = x.RequestCurrentWorkerFullName,
                    CurrentWorkerIsGroupFlag = x.CurrentWorkerIsGroupFlag,
                    ApplicationSourceID = x.ApplicationSourceID,
                    RequestTypeID = x.RequestTypeID,
                    RequestOriginID = x.RequestOriginID,
                    RequestPriorityID = x.RequestPriorityID,
                    RequestTaxpayerID = requestTaxpayerID,
                    RequestConcurrentCreationOfChildrenFlag = x.RequestConcurrentCreationOfChildrenFlag,
                    RequestComments = x.RequestComments,
                    RequestUpdateNotificationFlag = x.RequestUpdateNotificationFlag,
                    RequestUpdateNotificationEmail = x.RequestUpdateNotificationEmail,
                    DefaultStatusClosesRequest = x.RequestCompletionDate == null ? false : true
                }));

                db.RequestQueues.AddRange(requestQueues);
                db.SaveChanges();
            }
        }

        private string GetLastRequestNumber()
        {
            return db.Requests.Where(row => row.RequestYear == DateTime.Now.Year).DefaultIfEmpty().Max(row => row.RequestNumber == null ? "0" : row.RequestNumber).ToString();
        }

        private string GenerateRequestNumber(string lastRequestNumber)
        {
            string strFormat = "000000";
            int intNewApplicationNumber = Convert.ToInt32(lastRequestNumber) + 1;
            string strNewApplicationNumber = intNewApplicationNumber.ToString(strFormat);
            return strNewApplicationNumber;
        }

        private void SetRequestRelationships(short? requestYear, string requestNumber)
        {
            db.Database.ExecuteSqlCommand("[PSR].[SetRequestRelationships] @RequestYear, @RequestNumber",
                                    new SqlParameter("@RequestYear", requestYear),
                                    new SqlParameter("@RequestNumber", requestNumber));
        }

        private Request GenerateRequest(RequestCreateViewModel newPSR, AssociatedServiceTypeViewModel serviceType, string requestNumber, short requestYear, int counter, int totalServiceTypes, int? districtNo, bool blnIsAnonymous, List<RequestCustomFieldViewModel> customFields, bool generateChildRequests, DateTime dtNow, bool attachmentsIncluded)
        {
            var newRequest = new Request();

            bool isParentRootRequest = serviceType.ServiceTypeParentID == 0;
            //add folios, attachments, and custom fields, if any, to parent root request only
            if (isParentRootRequest)
            {
                newRequest.RequestFolios = AddFolios(newPSR.FolioList);
                newRequest.ServiceTypeCustomFieldTransactions = GetCustomFields(customFields, serviceType);
            }

            //map from PublicServiceRequestBusinessModel
            newRequest.RequestNumber = requestNumber;
            newRequest.ApplicationSourceID = 1;
            //if only one request suffix is zero otherwise request numbers for mutiple start at 1
            newRequest.RequestSuffix = totalServiceTypes == 1 ? counter : counter + 1;
            newRequest.RequestYear = requestYear;
            newRequest.RequestUpdateNotificationFlag = newPSR.RequestUpdateNotificationFlag;
            newRequest.RequestTypeID = 1;//PSR
            newRequest.RequestOriginID = newPSR.RequestOriginID;
            newRequest.RequestPriorityID = newPSR.RequestPriorityID;
            newRequest.ServiceTypeID = serviceType.ServiceTypeID;
            newRequest.RequestComments = newPSR.RequestComments;
            newRequest.RequestUpdateNotificationEmail = newPSR.RequestUpdateNotificationEmail;
            newRequest.RequestParentRootID = newPSR.ServiceTypeID;
            newRequest.RequestConcurrentCreationOfChildrenFlag = generateChildRequests;

            //if client sends a RequestTaxpayerID of -1 then the request has no taxpayer associated with it, therefore skip
            if (newPSR.RequestTaxpayerInfo.RequestTaxpayerID != -1)
            {
                //if RemainAnonymousFlag == true then assign to system reserved RequestTaxpayerID of 1 'Anonymous'
                newRequest.RequestTaxpayerID = blnIsAnonymous ? 1 : newPSR.RequestTaxpayerInfo.RequestTaxpayerID;
            }

            //map from servicetype
            newRequest.RequestImmediateParentID = serviceType.ServiceTypeParentID;
            newRequest.RequestStartTrigger = serviceType.ServiceTypeChildStartTriggerID;
            newRequest.RequestStartDelayDefinition = serviceType.ServiceTypeChildStartDelay;
            newRequest.RequestDurationDefinition = serviceType.ServiceTypeChildDuration;
            newRequest.RequestEscalationExpectedStatusID = serviceType.EscalationExpectedStatusID;
            newRequest.RequestChildrenCloseParentFlag = serviceType.ServiceTypeParentClosesWhenChildrenClosedFlag;
            newRequest.RequestEffectiveDate = serviceType.EffectiveDate;
            newRequest.AdjustedRequestEffectiveDate = serviceType.EffectiveDate;
            newRequest.RequestDueDate = serviceType.DueDate;
            newRequest.AdjustedRequestDueDate = serviceType.DueDate;
            newRequest.RequestStatusID = serviceType.DefaultRequestStatusID;
            newRequest.CurrentWorkerIsGroupFlag = true;

            if (serviceType.StatusClosesRequestFlag == true)
            {
                newRequest.RequestCompletionDate = dtNow;
            };

            //if comments by PA personnel were also included or attachments are included, generate a system reserved action
            if (!String.IsNullOrWhiteSpace(newPSR.RequestCommentsInternal) || attachmentsIncluded)
            {
                AddRequestAction(newRequest, newPSR.RequestCommentsInternal, 1, newPSR, isParentRootRequest, attachmentsIncluded);//System reserved action type                
            }

            if (serviceType.ServiceTypeAssigneeDependantOnOriginFlag && serviceType.ServiceTypeDependantOriginID == newPSR.RequestOriginID)
            {
                var originBasedOwnerGroup = db.ServiceTypeOwnerGroups.Where(x => x.ServiceTypeOwnerGroupID == serviceType.ServiceTypeOwnerGroupOverrideOriginBased).FirstOrDefault();
                newRequest.RequestCurrentOwnerGroupID = originBasedOwnerGroup.ServiceTypeOwnerGroupID;
                newRequest.RequestCurrentWorkerFullName = originBasedOwnerGroup.ServiceTypeOwnerGroupName;
            }
            //if request owner group assignment is folio dependant and district number in folio list is not null,
            //assign the owner group that corresponds with the district no in question, otherwise, set it to the default
            else if (districtNo != null && serviceType.ServiceTypeAssigneeDependantOnPropertyFlag == true)
            {
                var districtOwnerGroup = db.ServiceTypeOwnerGroups.Where(x => x.ServiceTypeOwnerGroupDistrictNo == districtNo).FirstOrDefault();
                newRequest.RequestCurrentOwnerGroupID = districtOwnerGroup.ServiceTypeOwnerGroupID;
                newRequest.RequestCurrentWorkerFullName = districtOwnerGroup.ServiceTypeOwnerGroupName;
            }
            else
            {
                newRequest.RequestCurrentOwnerGroupID = serviceType.ServiceTypeOwnerGroupID;
                newRequest.RequestCurrentWorkerFullName = serviceType.ServiceTypeOwnerGroupName;
            }

            return newRequest;
        }

        private List<RequestFolio> AddFolios(List<RequestFolioViewModel> folioList)
        {
            //use DistinctBy method from MoreLinq in case duplicate folio year combinations are submitted
            var distinctfolioList = folioList.DistinctBy(x=>new {x.Folio, x.Year });
            var requestFolios = new List<RequestFolio>();

            foreach (var folio in distinctfolioList)
            {
                requestFolios.Add(new RequestFolio
                {
                    Folio = folio.Folio,
                    FormattedFolio = folio.FormattedFolio,
                    RequestFolioTypeID = folio.RequestFolioTypeID,
                    SiteAddress = folio.SiteAddress,
                    SiteCity = folio.SiteCity,
                    MailingAddress = folio.MailingAddress,
                    MailingCity = folio.MailingCity,
                    MailingZipCode = folio.MailingZipCode,
                    ZipCode = folio.ZipCode,
                    Year = folio.Year,
                    District = folio.District,
                    HistoryRunID = folio.HistoryRunID,
                    DORCode = folio.DORCode,
                    Owner = folio.Owner,
                    CancelledAtTimeOfRequestFlag = folio.Cancelled == "Y" ? true : false,
                    ConfidentialAtTimeOfRequestFlag = folio.Confidential == "Y" ? true : false
                });
            }

            return requestFolios;
        }

        //private void AddRequestAction(Request request, string comments, int requestActionTypeID)
        //{
        //    request.RequestActions.Add(new RequestAction()
        //    {
        //        Comments = comments,
        //        RequestActionTypeID = requestActionTypeID,//System reserved action type
        //        IsReplicatedFlag = false
        //    });
        //}

        private void AddRequestAction(Request request, string comments, int requestActionTypeID, RequestCreateViewModel requestVM, bool isParentRootRequest, bool attachmentsIncluded)
        {
            var attachmentDate = DateTime.Now;
            var filePrefix = string.Format("PSR{0}-{1}_{2:yyyyMMdd_hh-mm-ss-tt}_", request.RequestYear, request.RequestNumber, attachmentDate);
            var subFolderName = DateTime.Now.Year.ToString();
            List<RequestAttachment> requestAttachments = new List<RequestAttachment>();

            //if serviceTypeParentID is 0 (first request) move files
            if (isParentRootRequest && attachmentsIncluded)
            {
                requestAttachments = GetRequestAttachments(requestVM, request.RequestYear, filePrefix, attachmentDate);
                requestAttachments = RequestUtilities.MoveAttachmentsFromTempToPermanentFile(requestAttachments, requestVM.ConfidentialOutputDirectory, requestVM.OutputDirectory, requestVM.AttachmentTemporaryID.ToString(), filePrefix, subFolderName);
            }

            request.RequestActions.Add(new RequestAction()
            {
                Comments = comments,
                RequestActionTypeID = requestActionTypeID,//System reserved action type
                IsReplicatedFlag = false,
                RequestAttachments = requestAttachments
            });
        }

        private List<RequestAttachment> GetRequestAttachments(RequestCreateViewModel requestVM, short? requestYear, string filePrefix, DateTime attachmentDate)
        {
            List<RequestAttachment> requestAttachments = new List<RequestAttachment>();

            foreach (var attachment in requestVM.RequestAttachments)
            {
                requestAttachments.Add(new RequestAttachment
                {
                    RequestAttachmentName = filePrefix + attachment.RequestAttachmentName,
                    RequestAttachmentFriendlyName = attachment.RequestAttachmentName,
                    RequestAttachmentComment = attachment.RequestAttachmentComment,
                    RequestAttachmentDate = attachmentDate,
                    SubFolder = attachmentDate.Year.ToString(),
                    AttachmentTypeID = 1,
                    SizeInKB = attachment.SizeInKB,
                    FileExtension = attachment.FileExtension,
                    ConfidentialAttachmentFlag = attachment.ConfidentialAttachmentFlag
                });
            }

            return requestAttachments;
        }

        private RequestTaxpayer AddTaxpayer(RequestCreateViewModel newPSR)
        {
            var newTaxpayer = new RequestTaxpayer()
            {
                FirstName = newPSR.RequestTaxpayerInfo.FirstName.Trim(),
                LastName = newPSR.RequestTaxpayerInfo.LastName.Trim(),
                MiddleInitial = newPSR.RequestTaxpayerInfo.MiddleInitial,
                PhoneNo = newPSR.RequestTaxpayerInfo.PhoneNo,
                Email = newPSR.RequestTaxpayerInfo.Email,
                RequestTaxpayerPreferredLanguageID = newPSR.RequestTaxpayerInfo.RequestTaxpayerPreferredLanguageID
            };

            db.RequestTaxpayers.Add(newTaxpayer);
            return newTaxpayer;
        }

        private List<ServiceTypeCustomFieldTransaction> GetCustomFields(List<RequestCustomFieldViewModel> customFields, AssociatedServiceTypeViewModel serviceType)
        {
            var customFieldTransactionsForNewRequest = new List<ServiceTypeCustomFieldTransaction>();
            //iterate through customfield values string array parameter and assign to each ServiceTypeCustomFieldTransaction for generated request
            for (var i = 0; i < customFields.Count(); i++)
            {
                //create new transaction record only of display data or selectlistdisplay data is not null
                if ((!string.IsNullOrWhiteSpace(customFields[i].DisplayData)) || (customFields[i].SelectListDisplayData != null))
                {
                    var customFieldTransaction = new ServiceTypeCustomFieldTransaction
                    {
                        ServiceTypeCustomFieldID = customFields[i].CustomFieldID,
                        DisplayData = customFields[i].CustomFieldTypeID >= 100 ? customFields[i].SelectListDisplayData.SelectListLabel : customFields[i].DisplayData,
                        Value = customFields[i].CustomFieldTypeID >= 100 ? customFields[i].SelectListDisplayData.SelectListValue : customFields[i].DisplayData
                    };
                    //add transaction to new request
                    customFieldTransactionsForNewRequest.Add(customFieldTransaction);
                }
            }
            return customFieldTransactionsForNewRequest;
        }

        private List<RequestEmailViewModel> GetGeneratedRequests(string requestNumber, short requestYear, string userName, string email)
        {
            List<RequestEmailViewModel> generatedRequests = null;
            //NOTE: join to ServiceTypeOwnerGroups is based on request's RequestCurrentOwnerGroupID NOT service types' [ServiceTypeOwnerGroupID] 
            //since the owner of a service may change if the service type's [ServiceTypeAssigneeDependantOnPropertyFlag] is set to true 
            //OR the [ServiceTypeOwnerGroupOverrideID] is current
            //PAGeneralDb db2 = new PAGeneralDb();
            using (var db2 = new PAGeneralDb())
            {
                generatedRequests = (from rq in db2.Requests
                                     join st in db2.ServiceTypes on rq.ServiceTypeID equals st.ServiceTypeID
                                     join tp in db2.RequestTaxpayers on rq.RequestTaxpayerID equals tp.RequestTaxpayerID into tpj
                                     from tp in tpj.DefaultIfEmpty()
                                     join pl in db2.RequestTaxpayerPreferredLanguages on tp.RequestTaxpayerPreferredLanguageID equals pl.RequestTaxpayerPreferredLanguageID into plj
                                     from pl in plj.DefaultIfEmpty()
                                     join og in db2.ServiceTypeOwnerGroups on rq.RequestCurrentOwnerGroupID equals og.ServiceTypeOwnerGroupID
                                     where rq.RequestNumber == requestNumber && rq.RequestYear == requestYear
                                     orderby rq.RequestSuffix
                                     select new RequestEmailViewModel()
                                     {
                                         RequestID = rq.RequestID,
                                         RequestSuffix = rq.RequestSuffix,
                                         ServiceTypeName = st.ServiceTypeName,
                                         FormattedRequestNumber = rq.FormattedRequestNumber,
                                         RequestAssignee = og.ServiceTypeOwnerGroupName,
                                         EmailToNewAssignment = og.ServiceTypeOwnerGroupNotificationEmail,
                                         Comments = rq.RequestComments,
                                         TaxpayerID = tp.RequestTaxpayerID,
                                         TaxpayerFirstName = tp.FirstName,
                                         TaxpayerLastName = tp.LastName,
                                         TaxpayerEmail = tp.Email,
                                         TaxpayerPhoneNo = tp.FormattedPhoneNo,
                                         TaxpayerMiddleInitial = tp.MiddleInitial,
                                         TaxpayerPreferredLanguage = pl.RequestTaxpayerPreferredLanguageName,
                                         FirstFolioNo = db2.RequestFolios.FirstOrDefault(x => x.RequestID == rq.RequestID).FormattedFolio,
                                         RequestCreationDate = rq.AdmDateAdded.ToString()
                                     }).ToList();

                generatedRequests[0].PersonWhoGeneratedRequest = userName;
                generatedRequests[0].EmailFrom = email;
            }

            return generatedRequests;
        }

        private void RequestInit(RequestCreateViewModel request, int? serviceTypeID)
        {
            //initialize request with default values

            //initialize lists for viewmodel
            request.TaxYearList = new List<string>();
            request.FolioList = new List<RequestFolioViewModel>();
            request.RequestAttachments = new List<RequestAttachmentWorkspaceViewModel>();
            request.RequestTaxpayerInfo = new RequestTaxpayerViewModel();
            request.RequestOrigins = new List<RequestOriginViewModel>();

            //get active directory groups found in identity claims
            var UserActiveDirectoryGroup = User.Identity.GetActiveDirectoryGroups().ToArray();

            var requestOrigins = (from ro in db.RequestOrigins
                                  select new RequestOriginViewModel()
                                  {
                                      RequestOriginID = ro.RequestOriginID,
                                      RequestOriginName = ro.RequestOriginName,
                                      AutoSelectedForActiveDirectoryGroup = ro.AutoSelectedForActiveDirectoryGroup,
                                      DisableProgressNotificationForAutoSelectedGroupFlag = ro.DisableProgressNotificationForAutoSelectedGroupFlag,
                                      ForceAutoSelectedOriginFlag = ro.ForceAutoSelectedOriginFlag,
                                      AdmIsActive = ro.AdmIsActive
                                  }).ToList();//db.RequestOrigins.OrderBy(x => x.RequestOriginName).ToList();

            //get the first requestOrigin whose AD group matches any identity AD group
            var defaultRequestOrigin = (from ro1 in requestOrigins
                                        where UserActiveDirectoryGroup.Contains(ro1.AutoSelectedForActiveDirectoryGroup)
                                        select new RequestOriginViewModel
                                        {
                                            RequestOriginID = ro1.RequestOriginID,
                                            DisableProgressNotificationForAutoSelectedGroupFlag = ro1.DisableProgressNotificationForAutoSelectedGroupFlag,
                                            ForceAutoSelectedOriginFlag = ro1.ForceAutoSelectedOriginFlag
                                        }).FirstOrDefault();

            //if a default origin exists for the AD group, determine if they can choose to be notified of request progress, otherwise set DisableProgressNotification to false
            //and whether they can override the default origin that is auto selected
            if (defaultRequestOrigin != null)
            {
                request.RequestOriginID = defaultRequestOrigin.RequestOriginID;
                request.DisableProgressNotification = defaultRequestOrigin.DisableProgressNotificationForAutoSelectedGroupFlag;

                if (defaultRequestOrigin.ForceAutoSelectedOriginFlag == true)
                {
                    request.RequestOrigins = requestOrigins.Where(x => x.RequestOriginID == defaultRequestOrigin.RequestOriginID).ToList();
                }
                else
                {
                    request.RequestOrigins = requestOrigins.Where(x => x.AdmIsActive == "Y").OrderBy(x => x.RequestOriginName).ToList();
                }
            }
            else
            {
                request.RequestOrigins = requestOrigins.Where(x => x.AdmIsActive == "Y").OrderBy(x => x.RequestOriginName).ToList();
            }

            request.ServiceTypeID = serviceTypeID;
            request.RequestPriorityID = 2;//Normal
            request.RequestUpdateNotificationEmail = User.Identity.GetEmail();
            request.RequestUpdateNotificationFlag = false;
            request.RequestTypeID = 1;//PSR
            request.AttachmentTemporaryID = Guid.NewGuid();

            //get current rollyear and populate taxyearlist for model
            var currentTaxYear = dbCAMA.GetCurrentRollYear();
            request.SelectedYear = currentTaxYear.ToString();
            for (var i = 0; i <= 10; i++)
            {
                request.TaxYearList.Add(currentTaxYear.ToString());
                currentTaxYear = currentTaxYear - 1;
            }
        }
        #endregion auxilliary methods

        #region default odata methods
        // POST: odata/Requests
        public async Task<IHttpActionResult> Post(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Requests.Add(request);
            await db.SaveChangesAsync();

            return Created(request);
        }

        // GET: odata/Requests
        [EnableQuery]
        public IQueryable<Request> GetRequests()
        {
            return db.Requests;
        }

        // GET: odata/Requests(5)
        [EnableQuery(MaxExpansionDepth = 3, AllowedQueryOptions = AllowedQueryOptions.All)]
        public SingleResult<Request> GetRequest([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(request => request.RequestID == key));
        }

        // PUT: odata/Requests(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Request> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Request request = await db.Requests.FindAsync(key);
            if (request == null)
            {
                return NotFound();
            }

            patch.Put(request);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(request);
        }

        // PATCH: odata/Requests(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Request> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Request request = await db.Requests.FindAsync(key);
            if (request == null)
            {
                return NotFound();
            }

            patch.Patch(request);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(request);
        }

        // DELETE: odata/Requests(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Request request = await db.Requests.FindAsync(key);
            if (request == null)
            {
                return NotFound();
            }

            db.Requests.Remove(request);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Requests(5)/RequestActions
        [EnableQuery]
        public IQueryable<RequestAction> GetRequestActions([FromODataUri] int key)
        {
            return db.Requests.Where(m => m.RequestID == key).SelectMany(m => m.RequestActions);
        }

        // GET: odata/Requests(5)/RequestActionAttachments
        [EnableQuery]
        public IQueryable<RequestAttachment> GetRequestAttachments([FromODataUri] int key)
        {
            return db.Requests.Where(m => m.RequestID == key).SelectMany(m => m.RequestAttachments);
        }

        // GET: odata/Requests(5)/RequestFolios
        [EnableQuery]
        public IQueryable<RequestFolio> GetRequestFolios([FromODataUri] int key)
        {
            return db.Requests.Where(m => m.RequestID == key).SelectMany(m => m.RequestFolios);
        }

        // GET: odata/Requests(5)/RequestOrigin
        [EnableQuery]
        public SingleResult<RequestOrigin> GetRequestOrigin([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.RequestOrigin));
        }

        // GET: odata/Requests(5)/RequestPriority
        [EnableQuery]
        public SingleResult<RequestPriority> GetRequestPriority([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.RequestPriority));
        }

        // GET: odata/Requests(5)/RequestStatus
        [EnableQuery]
        public SingleResult<RequestStatus> GetRequestStatus([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.RequestStatus));
        }

        // GET: odata/Requests(5)/RequestTaxpayer
        [EnableQuery]
        public SingleResult<RequestTaxpayer> GetRequestTaxpayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.RequestTaxpayer));
        }

        // GET: odata/Requests(5)/RequestType
        [EnableQuery]
        public SingleResult<RequestType> GetRequestType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.RequestType));
        }

        // GET: odata/Requests(5)/ServiceType
        [EnableQuery]
        public SingleResult<ServiceType> GetServiceType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.ServiceType));
        }

        // GET: odata/Requests(5)/ServiceTypeCustomFieldTransactions
        [EnableQuery]
        public IQueryable<ServiceTypeCustomFieldTransaction> GetServiceTypeCustomFieldTransactions([FromODataUri] int key)
        {
            return db.Requests.Where(m => m.RequestID == key).SelectMany(m => m.ServiceTypeCustomFieldTransactions);
        }

        // GET: odata/Requests(5)/ServiceTypeResolution
        [EnableQuery]
        public SingleResult<ServiceTypeResolution> GetServiceTypeResolution([FromODataUri] int key)
        {
            return SingleResult.Create(db.Requests.Where(m => m.RequestID == key).Select(m => m.ServiceTypeResolution));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int key)
        {
            return db.Requests.Count(e => e.RequestID == key) > 0;
        }
    }
    #endregion default odata methods
}
