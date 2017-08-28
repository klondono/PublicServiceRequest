namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeOwnerGroupLocation")]
    public partial class ServiceTypeOwnerGroupLocation : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceTypeOwnerGroupLocation()
        {
            ServiceTypeOwnerGroups = new HashSet<ServiceTypeOwnerGroup>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceTypeOwnerGroupLocationID { get; set; }

        [StringLength(50)]
        public string ServiceTypeOwnerGroupLocationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceTypeOwnerGroup> ServiceTypeOwnerGroups { get; set; }
    }
}
