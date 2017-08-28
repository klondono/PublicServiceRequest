namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeResolutionLink")]
    public partial class ServiceTypeResolutionLink : BaseClass
    {
        public int ServiceTypeResolutionLinkID { get; set; }

        public int? ServiceTypeResolutionID { get; set; }

        public int? ServiceTypeID { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceTypeResolution ServiceTypeResolution { get; set; }
    }
}
