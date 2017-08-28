using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class RequestActionTypeViewModel
    {
        public int? RequestID { get; set; }
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }
        public int? RequestParentRootID { get; set; }
        public string FormattedRequestNumber { get; set; }
        public bool? RequestUpdateNotificationFlag { get; set; }
        public string RequestUpdateNotificationEmail { get; set; }
        public int? RequestActionTypeID { get; set; }
        public bool? AssignUserFlag { get; set; }
        public string RequestActionTypeName { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public string Comments { get; set; }
        public bool ChangeRequestStatus { get; set; }
        public bool ReassignRequest { get; set; }
        public bool UploadDocument { get; set; }
        public bool UpdateServiceType { get; set; }
        public bool UpdateRequestFolio { get; set; }
        public bool ByPassClientSideValidation { get; set; }
        public bool ConcurrentCreationOfChildrenFlag { get; set; }
        public string PrecedenceConstraintRequestActionTypeIDValue { get; set; }
        public bool? PrecedenceConstraintLogicalOperatorIsORFlag { get; set; }
        public bool? PrecedenceConstraintSatisfied { get; set; }
        public string PrecedenceConstraintErrorMsg { get; set; }
        public bool? AllowReplicationFlag { get; set; }
        public string AddActionActiveDirectoryGroupName { get; set; }
        public bool AddActionPermission { get; set; }
        public string UpdateActionActiveDirectoryGroupName { get; set; }
        public bool UpdateActionPermission { get; set; }
        public string DeleteActionActiveDirectoryGroupName { get; set; }
        public bool DeleteActionPermission { get; set; }
        public int? MaximumAllowedOcurrence { get; set; }
        public bool? ExceededMaximumAllowedOcurrence { get; set; }
        public bool? CloseWhenChildrenAreClosedFlag { get; set; }
        public List<RequestCustomFieldViewModel> RequestActionCustomFields { get; set; }
        public List<RequestUserViewModel> RequestActionUsers { get; set; }
        public List<RequestOwnerGroupViewModel> RequestActionOwnerGroups { get; set; }
        public List<RequestActionStatusViewModel> RequestActionStatuses { get; set; }
        public RequestUserViewModel SelectedUser { get; set; }
        public RequestOwnerGroupViewModel SelectedOwnerGroup { get; set; }
        public RequestActionStatusViewModel SelectedStatus { get; set; }
        public ServiceTypeViewModel SelectedServiceType { get; set; }
        public List<RequestAttachmentWorkspaceViewModel> RequestAttachments { get; set; }
        public List<AssociatedRequestWorkspaceViewModel> AssociatedRequests { get; set; }
        public List<ServiceTypeViewModel> ServiceTypes { get; set; }
        public string OutputDirectory { get; set; }
        public string ConfidentialOutputDirectory { get; set; }
        public Guid AttachmentTemporaryID { get; set; }

    }

    public class ServiceTypeViewModel
    {
        public int ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeCompositeName { get; set; }
        public string ServiceTypeOwnerGroupName { get; set; }
    }

    public class RequestCustomFieldViewModel
    {
        public bool? ServiceTypeChildCheckedByDefaultFlag { get; set; }
        public int? RequestActionID { get; set; }
        public int? ServiceTypeID { get; set; }
        public int CustomFieldID { get; set; }
        public int? CustomFieldTypeID { get; set; }
        public string ErrorMessage { get; set; }
        public string RegularExpression { get; set; }
        public string LabelName { get; set; }
        public string DisplayData { get; set; }
        public string FieldValue { get; set; }
        public string PlaceholderText { get; set; }
        public string TextAlignment { get; set; }
        public int? InputSequence { get; set; }
        public bool? RequiredFlag { get; set; }
        public string TooltipMessage { get; set; }
        public bool? DisplayFieldValueInCommentsFlag { get; set; }
        public RequestCustomFieldSelectListViewModel SelectListDisplayData { get; set; }
        public List<RequestCustomFieldSelectListViewModel> SelectListItems { get; set; }

    }

    public class RequestCustomFieldSelectListViewModel
    {
        public string SelectListLabel { get; set; }
        public string SelectListValue { get; set; }
    }

    public class RequestUserViewModel
    {
        public string UserFullName { get; set; }
        public Guid? UserId { get; set; }
        public string UserEmail { get; set; }
    }
    public class RequestOwnerGroupViewModel
    {
        public string OwnerGroupName { get; set; }
        public Guid? OwnerGroupID { get; set; }
        public string Email { get; set; }
    }
    public class RequestActionStatusViewModel
    {
        public int? StatusValue { get; set; }
        public string StatusName { get; set; }
        public bool? StatusOpensRequest { get; set; }
        public bool? StatusClosesRequest { get; set; }

    }
}