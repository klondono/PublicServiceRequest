namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemSetting")]
    public partial class SystemSetting
    {
        public int SystemSettingID { get; set; }

        [Required]
        [StringLength(200)]
        public string SystemSettingName { get; set; }

        [StringLength(50)]
        public string SystemSettingCategory { get; set; }

        [StringLength(4000)]
        public string SystemSettingValue { get; set; }

        [StringLength(50)]
        public string SystemSettingUse { get; set; }

        [StringLength(50)]
        public string SystemSettingLookupKey { get; set; }

        [StringLength(200)]
        public string SystemSettingLookupValue { get; set; }

        [StringLength(50)]
        public string SystemSettingApplicationName { get; set; }

        [StringLength(50)]
        public string SystemSettingParameter { get; set; }

        [StringLength(200)]
        public string SystemSettingGroup { get; set; }

        public int? SystemSettingOrder { get; set; }

        public string SystemSettingMessage { get; set; }

        [StringLength(200)]
        public string SystemSettingLabel { get; set; }

        public DateTime? SystemBeginDate { get; set; }

        public DateTime? SystemEndDate { get; set; }

    }
}
