namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.View_PersonalPropertyData")]
    public partial class View_PersonalPropertyData
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HistoryRunID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string Folio { get; set; }

        [StringLength(9)]
        public string FormattedFolio { get; set; }

        public decimal? Year { get; set; }

        public int? District { get; set; }

        public int? DORCode { get; set; }

        [StringLength(33)]
        public string Owner { get; set; }

        [StringLength(33)]
        public string SiteAddress { get; set; }

        [StringLength(5)]
        public string ZipCode { get; set; }

        [StringLength(33)]
        public string MailingAddress { get; set; }

        [StringLength(33)]
        public string MailingCity { get; set; }

        [StringLength(5)]
        public string MailingZipCode { get; set; }

        public string Cancelled { get; set; }

        public string Confidential { get; set; }
    }
}
