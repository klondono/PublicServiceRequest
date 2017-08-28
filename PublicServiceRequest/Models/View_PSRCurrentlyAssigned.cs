namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.View_PSRCurrentlyAssigned")]
    public partial class View_PSRCurrentlyAssigned
    {
        [Key]
        public long RN { get; set; }

        public string CurrentlyAssigned { get; set; }
    }
}
