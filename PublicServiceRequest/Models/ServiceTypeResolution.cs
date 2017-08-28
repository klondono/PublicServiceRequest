namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeResolution")]
    public partial class ServiceTypeResolution : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeResolution()
        {
            Requests = new HashSet<Request>();
            ServiceTypeResolutionLinks = new HashSet<ServiceTypeResolutionLink>();
        }

        public int ServiceTypeResolutionID { get; set; }

        [StringLength(50)]
        public string ServiceTypeResolutionName { get; set; }

        [StringLength(255)]
        public string ServiceTypeResolutionDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeResolutionLink> ServiceTypeResolutionLinks { get; set; }
    }
}
