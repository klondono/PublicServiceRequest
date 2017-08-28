namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestFolio")]
    public partial class RequestFolio : BaseClass
    {
        public int RequestFolioID { get; set; }

        public int? RequestID { get; set; }

        public int? RequestFolioTypeID { get; set; }

        [StringLength(25)]
        public string Folio { get; set; }

        [StringLength(25)]
        public string FormattedFolio { get; set; }

        public short? Year { get; set; }

        public int? HistoryRunID { get; set; }

        public int? District { get; set; }

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

        public bool? CancelledAtTimeOfRequestFlag { get; set; }

        public bool? ConfidentialAtTimeOfRequestFlag { get; set; }

        public virtual Request Request { get; set; }

        public virtual RequestFolioType RequestFolioType { get; set; }
    }
}
