namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.AttachmentType")]
    public partial class AttachmentType : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttachmentType()
        {
            RequestAttachments = new HashSet<RequestAttachment>();
        }

        public int AttachmentTypeID { get; set; }

        public int ServiceTypeID { get; set; }

        [StringLength(50)]
        public string AttachmentTypeName { get; set; }

        [StringLength(255)]
        public string AttachmentDescription { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestAttachment> RequestAttachments { get; set; }
    }
}
