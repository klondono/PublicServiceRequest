namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.View_RequestFolioGrid")]
    public partial class View_RequestFolioGrid
    {
        [Key]
        public int RequestFolioID { get; set; }

        public int? RequestID { get; set; }

        public int? RequestFolioTypeID { get; set; }

        [StringLength(50)]
        public string RequestFolioTypeName { get; set; }

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

        [StringLength(1)]
        public string AdmIsActive { get; set; }

        public Guid? AdmUserAdded { get; set; }

        [StringLength(50)]
        public string AdmUserAddedFullName { get; set; }

        public DateTime? AdmDateAdded { get; set; }

        public Guid? AdmUserModified { get; set; }

        [StringLength(50)]
        public string AdmUserModifiedFullName { get; set; }

        public DateTime? AdmDateModified { get; set; }

        public int? Interviews { get; set; }

        public int? EnableInterview { get; set; }

        public bool? ConfidentialAtTimeOfRequestFlag { get; set; }

        public bool? UserCanViewConfidential { get; set; }
    }
}
