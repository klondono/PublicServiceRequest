using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class ApplicationViewModel
    {
        public string UploadFileDirectory { get; set; }

        public string ConfidentialUploadFileDirectory { get; set; }

        public string UploadMaxSizeInKB { get; set; }

        public string UploadDocumentFormats { get; set; }

        public string ApplicationNotification { get; set; }

        public string DocumentVirtualPath { get; set; }

        public string ConfidentialDocumentVirtualPath { get; set; }

        public string Environment { get; set; }

        public string LogInInfo { get; set; }

        public bool IsPAUser { get; set; }

    }
}