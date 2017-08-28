namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeSearchKeywordLink")]
    public partial class ServiceTypeSearchKeywordLink : BaseClass
    {
        public int ServiceTypeSearchKeywordLinkID { get; set; }

        public int? ServiceTypeID { get; set; }

        public int? ServiceTypeSearchKeywordID { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceTypeSearchKeyword ServiceTypeSearchKeyword { get; set; }
    }
}
