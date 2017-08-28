namespace CustomerService_PSR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSR.RequestActionTypeCustomField")]
    public partial class RequestActionTypeCustomField : BaseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequestActionTypeCustomField()
        {
            RequestActionCustomFieldTransactions = new HashSet<RequestActionCustomFieldTransaction>();
        }

        public int RequestActionTypeCustomFieldID { get; set; }

        public int? RequestActionTypeID { get; set; }

        public int? CustomFieldTypeID { get; set; }

        public int? CustomFieldDataTypeID { get; set; }

        [StringLength(50)]
        public string LabelName { get; set; }

        [StringLength(50)]
        public string PlaceholderText { get; set; }

        [StringLength(7)]
        public string TextAlignment { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? InputSequence { get; set; }

        public bool? RequiredFlag { get; set; }

        public bool? DisplayFieldValueInCommentsFlag { get; set; }

        [StringLength(255)]
        public string TooltipMessage { get; set; }

        [StringLength(25)]
        public string GroupingIdentifier1 { get; set; }

        [StringLength(25)]
        public string GroupingIdentifier2 { get; set; }

        public virtual CustomFieldDataType CustomFieldDataType { get; set; }

        public virtual CustomFieldType CustomFieldType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestActionCustomFieldTransaction> RequestActionCustomFieldTransactions { get; set; }

        public virtual RequestActionType RequestActionType { get; set; }
    }
}
