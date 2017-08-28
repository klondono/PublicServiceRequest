namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestAction")]
    public partial class RequestAction : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestAction()
        {
            RequestActionCustomFieldTransactions = new HashSet<RequestActionCustomFieldTransaction>();
            RequestAttachments = new HashSet<RequestAttachment>();
        }

        public int RequestActionID { get; set; }

        public int? RequestActionTypeID { get; set; }

        public int? RequestID { get; set; }

        public int? RequestStatusChangedID { get; set; }

        public Guid? RequestAssignedUserID { get; set; }
        public Guid? AssignedOwnerGroupID { get; set; }

        public string NewAssigneeName { get; set; }

        public string Comments { get; set; }

        public virtual Request Request { get; set; }

        public virtual RequestActionType RequestActionType { get; set; }

        public bool? IsReplicatedFlag { get; set; }

        public virtual RequestStatus RequestStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestActionCustomFieldTransaction> RequestActionCustomFieldTransactions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAttachment> RequestAttachments { get; set; }
        public virtual ServiceTypeOwnerGroup ServiceTypeOwnerGroup { get; set; }
    }
}
