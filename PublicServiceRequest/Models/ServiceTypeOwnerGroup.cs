namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeOwnerGroup")]
    public partial class ServiceTypeOwnerGroup : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeOwnerGroup()
        {
            ServiceTypes = new HashSet<ServiceType>();
            ServiceTypesForOverridingOwnerGroup = new HashSet<ServiceType>();
            Requests = new HashSet<Request>();
            RequestActions = new HashSet<RequestAction>();
        }
        public Guid? ServiceTypeOwnerGroupID { get; set; }

        public int? ServiceTypeOwnerGroupLocationID { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceTypeOwnerGroupName { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupDescription { get; set; }

        [StringLength(1000)]
        public string ServiceTypeOwnerAvailableToActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string ServiceTypeOwnerActiveDirectoryGroupName { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupMainEmail { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupNotificationEmail { get; set; }

        [StringLength(500)]
        public string ServiceTypeOwnerGroupEscalationEmail { get; set; }

        [StringLength(25)]
        public string ServiceTypeOwnerGroupPhoneNo { get; set; }

        public int? ServiceTypeOwnerGroupDistrictNo { get; set; }

        public bool? SelectableOnRequestCreationFlag { get; set; }

        public bool? SelectableOnRequestReassignmentFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAction> RequestActions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceType> ServiceTypesForOverridingOwnerGroup { get; set; }

        public virtual ServiceTypeOwnerGroupLocation ServiceTypeOwnerGroupLocation { get; set; }
    }
}
