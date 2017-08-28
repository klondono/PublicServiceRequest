namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq.Expressions;
    [Table("PSR.RequestQueue")]
    public partial class RequestQueue:BaseClass
    {
        public int RequestQueueID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? RequestImmediateParentID { get; set; }

        public int? RequestParentRootID { get; set; }

        public int? RequestStatusID { get; set; }

        public bool? DefaultStatusClosesRequest { get; set; }

        public int? RequestStartTrigger { get; set; }

        public short? RequestYear { get; set; }

        [StringLength(7)]
        public string RequestNumber { get; set; }

        public int RequestSuffix { get; set; }

        public int? RequestStartDelayDefinition { get; set; }

        public int? RequestDurationDefinition { get; set; }

        public int? RequestEscalationExpectedStatusID { get; set; }

        public bool? RequestChildrenCloseParentFlag { get; set; }

        public Guid? RequestCurrentWorkerID { get; set; }

        public Guid? RequestCurrentOwnerGroupID { get; set; }

        public string RequestCurrentWorkerFullName { get; set; }

        public bool? CurrentWorkerIsGroupFlag { get; set; }

        public int? ApplicationSourceID { get; set; }

        public int? RequestTypeID { get; set; }

        public int? RequestOriginID { get; set; }

        public int? RequestPriorityID { get; set; }

        public int? RequestTaxpayerID { get; set; }

        public bool RequestConcurrentCreationOfChildrenFlag { get; set; }

        [StringLength(1000)]
        public string RequestComments { get; set; }

        public bool? RequestUpdateNotificationFlag { get; set; }

        [StringLength(50)]
        public string RequestUpdateNotificationEmail { get; set; }

        public static Expression<Func<RequestQueue, Request>> SelectToRequest =
            x => new Request()
            {
                ServiceTypeID = x.ServiceTypeID,
                RequestImmediateParentID = x.RequestImmediateParentID,
                RequestParentRootID = x.RequestParentRootID,
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
                CurrentWorkerIsGroupFlag = x.CurrentWorkerIsGroupFlag,
                ApplicationSourceID = x.ApplicationSourceID,
                RequestTypeID = x.RequestTypeID,
                RequestOriginID = x.RequestOriginID,
                RequestPriorityID = x.RequestPriorityID,
                RequestTaxpayerID = x.RequestTaxpayerID,
                RequestConcurrentCreationOfChildrenFlag = x.RequestConcurrentCreationOfChildrenFlag,
                RequestComments = x.RequestComments,
                RequestUpdateNotificationFlag = x.RequestUpdateNotificationFlag,
                RequestUpdateNotificationEmail = x.RequestUpdateNotificationEmail,
                RequestEffectiveDate = DateTime.Now.AddDays(Convert.ToDouble(x.RequestStartDelayDefinition)),
                AdjustedRequestEffectiveDate = DateTime.Now.AddDays(Convert.ToDouble(x.RequestStartDelayDefinition)),
                RequestDueDate = DateTime.Now.AddDays(Convert.ToDouble(x.RequestStartDelayDefinition + x.RequestDurationDefinition)),
                AdjustedRequestDueDate = DateTime.Now.AddDays(Convert.ToDouble(x.RequestStartDelayDefinition + x.RequestDurationDefinition))
            };
    }
}
