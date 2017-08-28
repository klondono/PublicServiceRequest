using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class RequestTaxpayerViewModel : BaseClass
    {
        public int RequestTaxpayerID { get; set; }

        public int? RequestTaxpayerPreferredLanguageID { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public string FormattedTaxpayerName { get; set; }

        public string PhoneNo { get; set; }

        public string PhoneNoType { get; set; }

        public string AltPhoneNo1 { get; set; }

        public string AltPhoneNo1Type { get; set; }

        public string AltPhoneNo2 { get; set; }

        public string AltPhoneNo2Type { get; set; }

        public string Email { get; set; }

        public string AltEmail { get; set; }

        public bool RemainAnonymousFlag { get; set; }
    }
}