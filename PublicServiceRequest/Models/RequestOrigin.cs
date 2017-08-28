namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestOrigin")]
    public partial class RequestOrigin : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestOrigin()
        {
            Requests = new HashSet<Request>();
        }

        public int RequestOriginID { get; set; }

        [StringLength(50)]
        public string RequestOriginName { get; set; }

        [StringLength(255)]
        public string RequestOriginDescription { get; set; }

        [StringLength(1000)]
        public string AutoSelectedForActiveDirectoryGroup { get; set; }

        public bool? DisableProgressNotificationForAutoSelectedGroupFlag { get; set; }

        public bool? ForceAutoSelectedOriginFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
