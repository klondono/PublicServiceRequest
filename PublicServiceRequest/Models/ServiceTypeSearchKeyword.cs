namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeSearchKeyword")]
    public partial class ServiceTypeSearchKeyword : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeSearchKeyword()
        {
            ServiceTypeSearchKeywordLinks = new HashSet<ServiceTypeSearchKeywordLink>();
        }

        public int ServiceTypeSearchKeywordID { get; set; }

        [StringLength(50)]
        public string ServiceTypeSearchKeywordName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeSearchKeywordLink> ServiceTypeSearchKeywordLinks { get; set; }
    }
}
