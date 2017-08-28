namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeCustomFieldTransaction")]
    public partial class ServiceTypeCustomFieldTransaction : BaseClass
    {
        public int ServiceTypeCustomFieldTransactionID { get; set; }

        public int RequestID { get; set; }

        public int ServiceTypeCustomFieldID { get; set; }

        [Required]
        [StringLength(3000)]
        public string DisplayData { get; set; }

        [Required]
        [StringLength(1000)]
        public string Value { get; set; }

        public virtual Request Request { get; set; }

        //public virtual RequestActionType RequestActionType { get; set; }

        //public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceTypeCustomField ServiceTypeCustomField { get; set; }
    }
}
