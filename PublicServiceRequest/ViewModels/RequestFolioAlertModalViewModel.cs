using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class RequestFolioAlertModalViewModel
    {
        [Key]
        public int RequestID { get; set; }
        public string FormattedTaxpayerName {get; set;}
        public string AdmUserAddedFullName {get; set;}
        public DateTime? AdmDateAdded {get; set;}
        public string RequestCurrentWorkerFullName {get; set;}
        public string FormattedRequestNumber {get; set;}
        public string RequestComments {get; set;}
        public string ServiceTypeName {get; set;}
        public string RequestStatusName {get; set;}
        public string RequestStatusColor {get; set;}
    }
}