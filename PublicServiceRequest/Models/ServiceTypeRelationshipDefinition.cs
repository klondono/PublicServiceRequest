namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.ServiceTypeRelationshipDefinition")]
    public partial class ServiceTypeRelationshipDefinition : BaseClass
    {
        public int ServiceTypeRelationshipDefinitionID { get; set; }

        public int? ServiceTypeParentID { get; set; }

        public int? ServiceTypeChildID { get; set; }

        public int? ServiceTypeChildStartTriggerID { get; set; }

        public int? ServiceTypeChildStartDelay { get; set; }

        public int? ServiceTypeChildDuration { get; set; }

        public bool? ServiceTypeChildRequiredFlag { get; set; }

        public bool? ServiceTypeChildCheckedByDefaultFlag { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual ServiceType ServiceType1 { get; set; }

        public virtual ServiceTypeChildStartTrigger ServiceTypeChildStartTrigger { get; set; }
    }
}
