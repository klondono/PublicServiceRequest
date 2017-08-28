namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.CustomFieldType")]
    public partial class CustomFieldType : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomFieldType()
        {
            CustomFieldSelectListItems = new HashSet<CustomFieldSelectListItem>();
            ServiceTypeCustomFields = new HashSet<ServiceTypeCustomField>();
            RequestActionTypeCustomFields = new HashSet<RequestActionTypeCustomField>();
        }

        public int CustomFieldTypeID { get; set; }

        [StringLength(50)]
        public string CustomFieldTypeName { get; set; }

        [StringLength(500)]
        public string CustomFieldTypeDescription { get; set; }

        public bool? AllowEditFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomFieldSelectListItem> CustomFieldSelectListItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeCustomField> ServiceTypeCustomFields { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestActionTypeCustomField> RequestActionTypeCustomFields { get; set; }
    }
}
