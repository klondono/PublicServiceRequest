namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestFolioType")]
    public partial class RequestFolioType : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestFolioType()
        {
            RequestFolios = new HashSet<RequestFolio>();
        }

        public int RequestFolioTypeID { get; set; }

        [StringLength(50)]
        public string RequestFolioTypeName { get; set; }

        [StringLength(255)]
        public string RequestFoliotypeDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestFolio> RequestFolios { get; set; }
    }
}
