namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestTaxpayerPreferredLanguage")]
    public partial class RequestTaxpayerPreferredLanguage : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestTaxpayerPreferredLanguage()
        {
            RequestTaxpayers = new HashSet<RequestTaxpayer>();
        }

        public int RequestTaxpayerPreferredLanguageID { get; set; }

        [StringLength(50)]
        public string RequestTaxpayerPreferredLanguageName { get; set; }

        [StringLength(255)]
        public string RequestTaxpayerPreferredLanguageDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestTaxpayer> RequestTaxpayers { get; set; }
    }
}
