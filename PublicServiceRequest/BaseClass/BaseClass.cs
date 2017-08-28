using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public abstract class BaseClass
    {
        [StringLength(1)]
        [ScaffoldColumn(false)]
        public string AdmIsActive { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? AdmDateAdded { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? AdmDateModified { get; set; }

        public Guid? AdmUserAdded { get; set; }

        public Guid? AdmUserModified { get; set; }

        [StringLength(100)]
        public string AdmUserAddedFullName { get; set; }

        [StringLength(100)]
        public string AdmUserModifiedFullName { get; set; }

        [StringLength(64)]
        public string AdmUserAddedDomainName { get; set; }

        [StringLength(64)]
        public string AdmUserModifiedDomainName { get; set; }
    }
}