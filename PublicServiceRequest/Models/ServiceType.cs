namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceType")]
    public partial class ServiceType : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceType()
        {
            AttachmentTypes = new HashSet<AttachmentType>();
            Requests = new HashSet<Request>();
            ServiceTypeCustomFields = new HashSet<ServiceTypeCustomField>();
            ServiceTypeRelationshipDefinitions = new HashSet<ServiceTypeRelationshipDefinition>();
            ServiceTypeRelationshipDefinitions1 = new HashSet<ServiceTypeRelationshipDefinition>();
            ServiceTypeRequestActionTypeLinks = new HashSet<ServiceTypeRequestActionTypeLink>();
            ServiceTypeResolutionLinks = new HashSet<ServiceTypeResolutionLink>();
            ServiceTypeSearchKeywordLinks = new HashSet<ServiceTypeSearchKeywordLink>();
        }

        public int ServiceTypeID { get; set; }

        public Guid? ServiceTypeOwnerGroupID { get; set; }

        public int? DefaultRequestStatusID { get; set; }

        public int? EscalationExpectedStatusID { get; set; }

        public int ServiceTypeNumber { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideID { get; set; }

        [StringLength(4)]
        public string ServiceTypeOwnerGroupOverrideMonthDayFrom { get; set; }

        [StringLength(4)]
        public string ServiceTypeOwnerGroupOverrideMonthDayTo { get; set; }

        [StringLength(50)]
        public string ServiceTypeName { get; set; }

        [StringLength(255)]
        public string ServiceTypeDescription { get; set; }

        public int? ServiceTypeDefaultDuration { get; set; }

        public bool? ServiceTypeAssigneeDependantOnPropertyFlag { get; set; }

        public bool? ServiceTypeIncludePropertyInfoFlag { get; set; }

        public bool? ServiceTypeIncludeFirstActionCommentFlag { get; set; }

        public bool? ServiceTypeShowAsStandaloneServiceFlag { get; set; }

        public bool SelectableOnServiceTypeUpdateFlag { get; set; }

        public bool? ServiceTypeParentClosesWhenChildrenClosedFlag { get; set; }

        public bool ServiceTypeConcurrentCreationOfChildrenFlag { get; set; }

        [StringLength(1000)]
        public string ServiceTypeAvailableToActiveDirectoryGroupName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttachmentType> AttachmentTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        public virtual RequestStatus DefaultRequestStatusForServiceType { get; set; }

        public virtual RequestStatus EscalationExpectedStatusForServiceType { get; set; }

        public virtual ServiceTypeOwnerGroup ServiceTypeOwnerGroup { get; set; }

        public virtual ServiceTypeOwnerGroup OverridingServiceTypeOwnerGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRelationshipDefinition> ServiceTypeRelationshipDefinitions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeRequestActionTypeLink> ServiceTypeRequestActionTypeLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeResolutionLink> ServiceTypeResolutionLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeSearchKeywordLink> ServiceTypeSearchKeywordLinks { get; set; }

        public bool ServiceTypeAssigneeDependantOnOriginFlag { get; set; }

        public int? ServiceTypeDependantOriginID { get; set; }

        public Guid? ServiceTypeOwnerGroupOverrideOriginBased { get; set; }

        public int? DefaultRequestFolioTypeID { get; set; }

        public bool ForceRequestFolioType { get; set; }
    }
}
