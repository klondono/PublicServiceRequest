using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class RequestCreateViewModel : BaseClass
    {
        public int RequestID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? RequestTypeID { get; set; }

        public int? RequestOriginID { get; set; }

        public int? RequestPriorityID { get; set; }

        public int? RequestStatusID { get; set; }

        public int? RequestResolutionID { get; set; }

        public int? RequestTaxpayerID { get; set; }

        public Guid? RequestCurrentWorkerID { get; set; }

        public bool? DisableProgressNotification { get; set; }

        public string RequestCurrentWorkerFullName { get; set; }

        public short? RequestYear { get; set; }

        public string RequestNumber { get; set; }

        public int? RequestSuffix { get; set; }

        public string FormattedRequestNumber { get; set; }

        public DateTime? RequestDueDate { get; set; }

        public string RequestComments { get; set; }

        public string RequestCommentsInternal { get; set; }

        public DateTime? RequestEffectiveDate { get; set; }

        public DateTime? RequestCompletionDate { get; set; }

        public bool? RequestUpdateNotificationFlag { get; set; }

        public string RequestUpdateNotificationEmail { get; set; }

        public List<RequestFolioViewModel> FolioList { get; set; }

        public List<RequestOriginViewModel> RequestOrigins { get; set; }

        public List<string> TaxYearList { get; set; }

        public string SelectedYear { get; set;}

        public string OutputDirectory { get; set; }

        public string ConfidentialOutputDirectory { get; set; }

        public RequestTaxpayerViewModel RequestTaxpayerInfo { get; set; }
        public Guid AttachmentTemporaryID { get; set; }
        public List<RequestAttachmentWorkspaceViewModel> RequestAttachments { get; set; }

    }

    public class RequestOriginViewModel
    {
        public int RequestOriginID { get; set; }

        public string RequestOriginName { get; set; }

        public string RequestOriginDescription { get; set; }

        public string AutoSelectedForActiveDirectoryGroup { get; set; }

        public bool? DisableProgressNotificationForAutoSelectedGroupFlag { get; set; }

        public bool? ForceAutoSelectedOriginFlag { get; set; }

        public string AdmIsActive { get; set; }
    }
}