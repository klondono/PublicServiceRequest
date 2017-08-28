namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestStatus")]
    public partial class RequestStatus : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestStatus()
        {
            Requests = new HashSet<Request>();
            Requests__EscalationExpectedStatus = new HashSet<Request>();
            RequestActions = new HashSet<RequestAction>();
            ServiceTypes_DefaultRequestStatus = new HashSet<ServiceType>();
            ServiceTypes_EscalationExpectedStatus = new HashSet<ServiceType>();
        }

        [Key]
        public int RequestStatusID { get; set; }

        [StringLength(50)]
        public string RequestStatusName { get; set; }

        [StringLength(500)]
        public string RequestStatusDescription { get; set; }

        [StringLength(20)]
        public string RequestStatusColor { get; set; }

        public bool? StatusReopensRequestFlag { get; set; }

        public bool? StatusClosesRequestFlag { get; set; }

        public bool? SystemReservedFlag { get; set; }

        public bool? SelectableOnRequestStatusChangeListFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAction> RequestActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes_DefaultRequestStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes_EscalationExpectedStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests__EscalationExpectedStatus { get; set; }
    }
}
