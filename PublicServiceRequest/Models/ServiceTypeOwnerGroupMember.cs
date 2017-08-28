namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeOwnerGroupMember")]
    public partial class ServiceTypeOwnerGroupMember : BaseClass
    {
        public int ServiceTypeOwnerGroupMemberID { get; set; }

        public int? ServiceTypeOwnerGroupID { get; set; }

        public int? MemberID { get; set; }
    }
}
