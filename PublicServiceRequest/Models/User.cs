using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService_PSR.Models
{
    [Table("IS.AD_Users")]
    public partial class User
    {
        [Key]
        public Guid? Id { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(101)]
        public string FullName { get; set; }

    }
}