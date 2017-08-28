namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestAttachment")]
    public partial class RequestAttachment : BaseClass
    {
        public int RequestAttachmentID { get; set; }

        public int? RequestID { get; set; }

        public int? RequestActionID { get; set; }

        public int? AttachmentTypeID { get; set; }

        [StringLength(255)]
        public string RequestAttachmentComment { get; set; }

        [StringLength(500)]
        public string RequestAttachmentName { get; set; }

        [StringLength(500)]
        public string RequestAttachmentFriendlyName { get; set; }

        public bool? ConfidentialAttachmentFlag { get; set; }

        public int? SizeInKB { get; set; }

        [StringLength(50)]
        public string SubFolder { get; set; }

        [StringLength(10)]
        public string FileExtension { get; set; }

        public DateTime? RequestAttachmentDate { get; set; }

        public virtual AttachmentType AttachmentType { get; set; }

        public virtual Request Request { get; set; }

        public DateTime? Imported { get; set; }

        public virtual RequestAction RequestAction { get; set; }
    }
}
