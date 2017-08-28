namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.View_PSRAdmUserAdded")]
    public partial class View_PSRAdmUserAdded
    {
        [Key]
        public long RN { get; set; }

        public string CreatedBy { get; set; }
    }
}
