namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.View_RequestMainSearchGridWFolio")]
    public partial class View_RequestMainSearchGridWFolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }

        [StringLength(7)]
        public string RequestNumber { get; set; }

        public short? RequestYear { get; set; }

        public int? RequestSuffix { get; set; }

        [StringLength(92)]
        public string FormattedRequestNumber { get; set; }

        public int? RequestStatusID { get; set; }

        public int? ServiceTypeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestEffectiveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdmDateAdded { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdmDateAddedNoTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequestCompletionDate { get; set; }

        [StringLength(50)]
        public string ServiceTypeName { get; set; }

        [StringLength(50)]
        public string RequestStatusName { get; set; }

        [StringLength(20)]
        public string RequestStatusColor { get; set; }

        [StringLength(50)]
        public string RequestPriorityName { get; set; }

        [StringLength(103)]
        public string Requestor { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public bool? CurrentWorkerIsGroupFlag { get; set; }

        [StringLength(100)]
        public string CurrentlyAssigned { get; set; }

        [StringLength(25)]
        public string Folio { get; set; }

        public int? Count { get; set; }

        [StringLength(50)]
        public string RequestOriginName { get; set; }
    }
}
