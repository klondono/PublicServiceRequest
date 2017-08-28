var app;
(function (app) {
    var domain;
    (function (domain) {
        var Request = (function () {
            function Request(RequestID, ServiceTypeID, RequestTypeID, RequestOriginID, RequestPriorityID, RequestStatusID, RequestResolutionID, RequestTaxpayerID, RequestCurrentWorkerID, RequestCurrentWorkerFullName, RequestYear, RequestNumber, RequestSuffix, FormattedRequestNumber, RequestDueDate, RequestComments, RequestEffectiveDate, RequestCompletionDate, RequestUpdateNotificationFlag, RequestUpdateNotificationEmail, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified, OutputDirectory, ConfidentialOutputDirectory, FolioList, AttachmentTemporaryID, DisableProgressNotification, RestrictToAutoSelection, RequestAttachments, RequestTaxpayerInfo, TaxYearList, SelectedYear, RequestOrigins, RequestCommentsInternal) {
                this.RequestID = RequestID;
                this.ServiceTypeID = ServiceTypeID;
                this.RequestTypeID = RequestTypeID;
                this.RequestOriginID = RequestOriginID;
                this.RequestPriorityID = RequestPriorityID;
                this.RequestStatusID = RequestStatusID;
                this.RequestResolutionID = RequestResolutionID;
                this.RequestTaxpayerID = RequestTaxpayerID;
                this.RequestCurrentWorkerID = RequestCurrentWorkerID;
                this.RequestCurrentWorkerFullName = RequestCurrentWorkerFullName;
                this.RequestYear = RequestYear;
                this.RequestNumber = RequestNumber;
                this.RequestSuffix = RequestSuffix;
                this.FormattedRequestNumber = FormattedRequestNumber;
                this.RequestDueDate = RequestDueDate;
                this.RequestComments = RequestComments;
                this.RequestEffectiveDate = RequestEffectiveDate;
                this.RequestCompletionDate = RequestCompletionDate;
                this.RequestUpdateNotificationFlag = RequestUpdateNotificationFlag;
                this.RequestUpdateNotificationEmail = RequestUpdateNotificationEmail;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
                this.OutputDirectory = OutputDirectory;
                this.ConfidentialOutputDirectory = ConfidentialOutputDirectory;
                this.FolioList = FolioList;
                this.AttachmentTemporaryID = AttachmentTemporaryID;
                this.DisableProgressNotification = DisableProgressNotification;
                this.RestrictToAutoSelection = RestrictToAutoSelection;
                this.RequestAttachments = RequestAttachments;
                this.RequestTaxpayerInfo = RequestTaxpayerInfo;
                this.TaxYearList = TaxYearList;
                this.SelectedYear = SelectedYear;
                this.RequestOrigins = RequestOrigins;
                this.RequestCommentsInternal = RequestCommentsInternal;
            }
            return Request;
        }());
        domain.Request = Request;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=request.js.map