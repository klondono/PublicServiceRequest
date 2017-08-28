using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class RequestFolioViewModel : BaseClass
    {
        public int RequestFolioID { get; set; }

        public int? RequestFolioTypeID { get; set; }

        public int? RequestID { get; set; }

        public string RequestFolioTypeName { get; set; }

        public string Folio { get; set; }

        public string FormattedFolio { get; set; }

        public short? Year { get; set; }

        public int? HistoryRunID { get; set; }

        public int? District { get; set; }

        public string DORCode { get; set; }

        public string Owner { get; set; }

        public string SiteAddress { get; set; }

        public string SiteCity { get; set; }

        public string ZipCode { get; set; }

        public string MailingAddress { get; set; }

        public string MailingCity { get; set; }

        public string MailingZipCode { get; set; }

        public string Confidential { get; set; }

        public string Cancelled { get; set; }

        public bool HasOpenPSR { get; set; }
    }
}