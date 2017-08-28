namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestActionCustomFieldTransaction")]
    public partial class RequestActionCustomFieldTransaction : BaseClass
    {
        public int RequestActionCustomFieldTransactionID { get; set; }

        public int RequestActionID { get; set; }

        public int RequestActionTypeCustomFieldID { get; set; }

        [Required]
        [StringLength(3000)]
        public string DisplayData { get; set; }

        [Required]
        [StringLength(1000)]
        public string FieldValue { get; set; }

        public virtual RequestAction RequestAction { get; set; }

        public virtual RequestActionTypeCustomField RequestActionTypeCustomField { get; set; }
    }
}
