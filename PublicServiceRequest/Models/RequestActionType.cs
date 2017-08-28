namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestActionType")]
    public partial class RequestActionType : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestActionType()
        {
            RequestActions = new HashSet<RequestAction>();
            RequestActionTypeCustomFields = new HashSet<RequestActionTypeCustomField>();
            ServiceTypeRequestActionTypeLinks = new HashSet<ServiceTypeRequestActionTypeLink>();
        }

        public int RequestActionTypeID { get; set; }

        [StringLength(50)]
        public string RequestActionTypeName { get; set; }

        [StringLength(255)]
        public string RequestActionTypeDescription { get; set; }

        [StringLength(7)]
        public string BackgroundColor { get; set; }

        [StringLength(7)]
        public string TextColor { get; set; }

        public bool ChangeRequestStatusFlag { get; set; }

        public bool ReassignRequestFlag { get; set; }

        public bool AllowReplicationFlag { get; set; }

        public bool AllowUpdateOfServiceTypeFlag { get; set; }

        public bool AllowUpdateOfRequestFolioFlag { get; set; }

        public bool ByPassClientSideValidationFlag { get; set; }

        public bool DisplayFlag { get; set; }

        public bool UploadDocumentFlag { get; set; }

        public bool SystemReservedFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAction> RequestActions { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ServiceTypeCustomFieldTransaction> ServiceTypeCustomFieldTransactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }
    }
}
