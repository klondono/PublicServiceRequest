namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    [Table("PSR.Request")]
    public partial class Request : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            ServiceTypeCustomFieldTransactions = new HashSet<ServiceTypeCustomFieldTransaction>();
            RequestActions = new HashSet<RequestAction>();
            RequestAttachments = new HashSet<RequestAttachment>();
            RequestFolios = new HashSet<RequestFolio>();
        }

        public int RequestID { get; set; }

        public int? ApplicationSourceID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? RequestTypeID { get; set; }

        public int? RequestOriginID { get; set; }

        public int? RequestPriorityID { get; set; }

        public int? RequestStatusID { get; set; }

        public int? RequestResolutionID { get; set; }

        public int? RequestTaxpayerID { get; set; }

        public Guid? RequestCurrentOwnerGroupID { get; set; }

        public Guid? RequestCurrentWorkerID { get; set; }

        public bool? CurrentWorkerIsGroupFlag { get; set; }

        [StringLength(100)]
        public string RequestCurrentWorkerFullName { get; set; }

        public short? RequestYear { get; set; }

        [StringLength(7)]
        public string RequestNumber { get; set; }

        public int RequestSuffix { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(92)]
        public string FormattedRequestNumber { get; set; }

        public DateTime? RequestDueDate { get; set; }

        [StringLength(2000)]
        public string RequestComments { get; set; }

        public DateTime? RequestEffectiveDate { get; set; }

        public DateTime? RequestCompletionDate { get; set; }

        public DateTime? AdjustedRequestEffectiveDate { get; set; }

        public DateTime? AdjustedRequestDueDate { get; set; }

        public bool? RequestUpdateNotificationFlag { get; set; }

        public int? RequestStartTrigger { get; set; }

        public int? RequestParentRootID { get; set; }

        public int? RequestImmediateParentID { get; set; }

        public int? RequestStartDelayDefinition { get; set; }

        public int? RequestDurationDefinition { get; set; }

        public int? RequestEscalationExpectedStatusID { get; set; }

        public bool? RequestChildrenCloseParentFlag { get; set; }
        public bool RequestConcurrentCreationOfChildrenFlag { get; set; }
        [StringLength(50)]
        public string RequestUpdateNotificationEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeCustomFieldTransaction> ServiceTypeCustomFieldTransactions { get; set; }

        public virtual RequestOrigin RequestOrigin { get; set; }

        public virtual RequestPriority RequestPriority { get; set; }

        public virtual RequestStatus RequestStatus { get; set; }

        public virtual RequestTaxpayer RequestTaxpayer { get; set; }

        public virtual RequestType RequestType { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceTypeResolution ServiceTypeResolution { get; set; }

        public virtual ServiceTypeOwnerGroup ServiceTypeOwnerGroup { get; set; }

        public virtual RequestStatus EscalationExpectedStatusForServiceType { get; set; }

        public virtual ApplicationSource ApplicationSource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAction> RequestActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAttachment> RequestAttachments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestFolio> RequestFolios { get; set; }

        public virtual ServiceTypeChildStartTrigger ServiceTypeChildStartTrigger { get; set; }

        public static void SetRequestRelationships(short? requestYear, string requestNumber, PAGeneralDb db)
        {
            db.Database.ExecuteSqlCommand("[PSR].[SetRequestRelationships] @RequestYear, @RequestNumber",
                                    new SqlParameter("@RequestYear", requestYear),
                                    new SqlParameter("@RequestNumber", requestNumber));
        }

    }
}
