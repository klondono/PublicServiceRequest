namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.View_RequestFolioByRequestNumberAndYear")]
    public partial class View_RequestFolioByRequestNumberAndYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestFolioID { get; set; }

        [StringLength(50)]
        public string RequestFolioTypeName { get; set; }

        [StringLength(25)]
        public string Folio { get; set; }

        [StringLength(25)]
        public string FormattedFolio { get; set; }

        public short? Year { get; set; }

        public int? HistoryRunID { get; set; }

        [StringLength(100)]
        public string DORCode { get; set; }

        [StringLength(200)]
        public string Owner { get; set; }

        [StringLength(500)]
        public string SiteAddress { get; set; }

        [StringLength(500)]
        public string SiteCity { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(500)]
        public string MailingAddress { get; set; }

        [StringLength(500)]
        public string MailingCity { get; set; }

        [StringLength(20)]
        public string MailingZipCode { get; set; }

        public short? RequestYear { get; set; }

        [StringLength(5)]
        public string RequestNumber { get; set; }
    }
}
