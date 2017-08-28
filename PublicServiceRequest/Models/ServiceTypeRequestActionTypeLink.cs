namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeRequestActionTypeLink")]
    public partial class ServiceTypeRequestActionTypeLink : BaseClass
    {
        public int ServiceTypeRequestActionTypeLinkID { get; set; }

        public int ServiceTypeID { get; set; }

        public int RequestActionTypeID { get; set; }

        public int? RequestWorkspaceDisplayCode { get; set; }

        public virtual RequestActionType RequestActionType { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public int? MaximumAllowedOcurrence { get; set; }

        public int? ListSequence { get; set; }

        [StringLength(1000)]
        public string PrecedenceConstraintRequestActionTypeIDValue { get; set; }

        public bool? PrecedenceConstraintLogicalOperatorIsORFlag { get; set; }

        [StringLength(1000)]
        public string AddActionActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string UpdateActionActiveDirectoryGroupName { get; set; }

        [StringLength(1000)]
        public string DeleteActionActiveDirectoryGroupName { get; set; }
    }
}
