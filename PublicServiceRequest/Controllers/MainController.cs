using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using CustomerService_PSR.Models;
using CustomerService_PSR.Utilities;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        PAPortalDb PAPortaldb = new PAPortalDb();
        // GET: Main
        public ActionResult Index()
        {
            var OfflineStartTime = PAPortaldb.GetSystemSetting("App_CustomerService_PSR_Offline_Start").SystemSettingValue;
            var OfflineEndTime = PAPortaldb.GetSystemSetting("App_CustomerService_PSR_Offline_End").SystemSettingValue;

            if (DateTime.Now >= Convert.ToDateTime(OfflineStartTime) && DateTime.Now <= Convert.ToDateTime(OfflineEndTime))
            {
                return View("Offline");
            }
            var applicationViewModel = new ApplicationViewModel();
            applicationViewModel.IsPAUser = User.IsInActiveDirectoryGroup("(PA) Users");
            applicationViewModel.LogInInfo = User.Identity.GetActiveDirectoryDisplayName() + " - " + DateTime.Now.ToString("d");
            applicationViewModel.Environment = Environment.GetEnvironmentVariable("PAENVIRONMENT") == "TEST" ? "- Test Environment" : "";

            applicationViewModel.UploadFileDirectory = PAPortaldb.GetSystemSetting("App_MVC_Uploader_NoConfidentialFileFolder").SystemSettingValue;
            applicationViewModel.ConfidentialUploadFileDirectory = PAPortaldb.GetSystemSetting("App_MVC_Uploader_ConfidentialFileFolder").SystemSettingValue;
            applicationViewModel.UploadMaxSizeInKB = PAPortaldb.GetSystemSetting("App_MVC_Uploader_MaxFileSize").SystemSettingValue;
            applicationViewModel.UploadDocumentFormats = PAPortaldb.GetSystemSetting("App_MVC_Uploader_AllowedFormats").SystemSettingValue;

            var AppMsgSystemSetting = PAPortaldb.GetSystemSetting("App_CustomerService_PSR_ImportantMsg");
            applicationViewModel.ApplicationNotification = AppMsgSystemSetting == null ? "" : AppMsgSystemSetting.SystemSettingValue;

            var virtualPath = PAPortaldb.GetSystemSetting("App_MVC_Uploader_VirtualPath").SystemSettingValue;
            applicationViewModel.DocumentVirtualPath = GetDocumentVirtualPath(PAPortaldb, virtualPath, applicationViewModel.UploadFileDirectory);
            applicationViewModel.ConfidentialDocumentVirtualPath = GetConfidentialDocumentVirtualPath(PAPortaldb, virtualPath, applicationViewModel.ConfidentialUploadFileDirectory);

            return View(applicationViewModel);
        }

        private string GetDocumentVirtualPath(PAPortalDb PAPortaldb, string virtualPath, string UploadFileDirectory)
        {
            string strFolder = UploadFileDirectory.Split('\\').Last();
            return virtualPath += strFolder + "/PSR/";
        }

        private string GetConfidentialDocumentVirtualPath(PAPortalDb PAPortaldb, string virtualPath, string ConfidentialFileDirectory)
        {
            string strFolder = ConfidentialFileDirectory.Split('\\').Last(); //PAPortaldb.GetSystemSetting("App_MVC_Uploader_ConfidentialFileFolder").SystemSettingValue.Split('\\').Last();
            return virtualPath += strFolder + "/PSR/";
        }

        public ActionResult SaveUploadedFile(IEnumerable<HttpPostedFileBase> files, string OutputDirectory, string TempID)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                var strOutputDirectory = OutputDirectory + @"\PSR\" + TempID + "_Temp";

                if (!Directory.Exists(strOutputDirectory))
                {
                    Directory.CreateDirectory(strOutputDirectory);
                }

                foreach (var file in files)
                {
                    // Some browsers send file names with full path. This needs to be stripped.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(strOutputDirectory, fileName);

                    file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult RemoveUploadedFile(string[] fileNames, string OutputDirectory, string TempID)
        {
            // The parameter of the Remove action must be called "fileNames"
            var strOutputDirectory = OutputDirectory + @"\PSR\" + TempID + "_Temp";

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(strOutputDirectory, fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PAPortaldb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}