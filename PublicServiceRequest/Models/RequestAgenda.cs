namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestAgenda")]
    public partial class RequestAgenda : BaseClass
    {
        [Key]
        public int RequestAgendaID { get; set; }

        public int RequestID { get; set; }


        [StringLength(7)]
        public string RequestAgendaNumber { get; set; }

        [StringLength(2000)]
        public string DecisionComment { get; set; }

        [StringLength(255)]
        public string ReconsiderationReason { get; set; }

        [StringLength(255)]
        public string Decision { get; set; }
    }
}
