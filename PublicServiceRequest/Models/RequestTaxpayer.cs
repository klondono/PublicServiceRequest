namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestTaxpayer")]
    public partial class RequestTaxpayer : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestTaxpayer()
        {
            Requests = new HashSet<Request>();
        }

        public int RequestTaxpayerID { get; set; }

        public int? RequestTaxpayerPreferredLanguageID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(1)]
        public string MiddleInitial { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(103)]
        public string FormattedTaxpayerName { get; set; }

        [StringLength(30)]
        public string PhoneNo { get; set; }

        [StringLength(30)]
        public string PhoneNoType { get; set; }

        [StringLength(30)]
        public string AltPhoneNo1 { get; set; }

        [StringLength(30)]
        public string AltPhoneNo1Type { get; set; }

        [StringLength(30)]
        public string AltPhoneNo2 { get; set; }

        [StringLength(30)]
        public string AltPhoneNo2Type { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(14)]
        public string FormattedPhoneNo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(14)]
        public string FormattedAltPhoneNo1 { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(14)]
        public string FormattedAltPhoneNo2 { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string AltEmail { get; set; }

        public bool? SystemReservedFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        public virtual RequestTaxpayerPreferredLanguage RequestTaxpayerPreferredLanguage { get; set; }
    }
}
