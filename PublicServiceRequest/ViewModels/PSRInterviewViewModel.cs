using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class PSRInterviewViewModel
    {
        [Key]
        public int RequestFolioID {get; set;}

        public int InterviewID { get; set; }

        public string Folio { get; set; }

        public int RequestID { get; set; }

        public string FormattedRequestNumber { get; set; }

        public int Year { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedDate { get; set; }

        public string FullName { get; set; }

        public string StatusType { get; set; }

        public string Recommendation { get; set; }
 
    }
}