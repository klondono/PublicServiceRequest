using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class AssociatedServiceTypeContainerViewModel
    {
        public List<AssociatedServiceTypeViewModel> AssociatedServiceTypes { get; set; }

        public List<RequestCustomFieldViewModel> CustomFields { get; set; }
    }

    public class AssociatedServiceTypeViewModel
    {
        public int? ServiceTypeID { get; set; }

        public string ServiceTypeName { get; set; }

        public int? ServiceTypeParentID { get; set; }

        public string ServiceTypeParentName { get; set; }

        public string ServiceTypeDescription { get; set; }

        public Guid? ServiceTypeOwnerGroupID { get; set; }

        public string ServiceTypeOwnerGroupName { get; set; }

        public int? DefaultRequestStatusID { get; set; }

        public bool? StatusClosesRequestFlag { get; set; }

        public int? EscalationExpectedStatusID { get; set; }

        public string ServiceTypeOwnerGroupNotificationEmail { get; set; }

        public string ServiceTypeOwnerGroupEscalationEmail { get; set; }

        public bool? ServiceTypeAssigneeDependantOnPropertyFlag { get; set; }

        public int? District { get; set; }

        public bool? ServiceTypeIncludePropertyInfoFlag { get; set; }

        public bool? ServiceTypeIncludeFirstActionCommentFlag { get; set; }

        public bool? ServiceTypeShowAsStandaloneServiceFlag { get; set; }

        public bool? ServiceTypeParentClosesWhenChildrenClosedFlag { get; set; }

        public bool? ServiceTypeChildRequiredFlag { get; set; }

        public bool? ServiceTypeChildCheckedByDefaultFlag { get; set; }

        public bool ServiceTypeConcurrentCreationOfChildrenFlag { get; set; }

        public int? ServiceTypeChildStartDelay { get; set; }

        public int? ServiceTypeChildDuration { get; set; }

        public int? ServiceTypeChildStartTriggerID { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public DateTime? DueDate { get; set; }

        public bool ServiceTypeAssigneeDependantOnOriginFlag { get; set; }

        public int? ServiceTypeDependantOriginID { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideOriginBased { get; set; }

        public int? DefaultRequestFolioTypeID { get; set; }

        public bool ForceRequestFolioType { get; set; }

        public int TreeLevel { get; set; }

    }
}