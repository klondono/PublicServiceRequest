var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestOrigin = (function () {
            function RequestOrigin(RequestOriginID, RequestOriginName, RequestOriginDescription, AutoSelectedForActiveDirectoryGroup, DisableProgressNotificationForAutoSelectedGroupFlag, ForceAutoSelectedOriginFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.RequestOriginID = RequestOriginID;
                this.RequestOriginName = RequestOriginName;
                this.RequestOriginDescription = RequestOriginDescription;
                this.AutoSelectedForActiveDirectoryGroup = AutoSelectedForActiveDirectoryGroup;
                this.DisableProgressNotificationForAutoSelectedGroupFlag = DisableProgressNotificationForAutoSelectedGroupFlag;
                this.ForceAutoSelectedOriginFlag = ForceAutoSelectedOriginFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return RequestOrigin;
        }());
        domain.RequestOrigin = RequestOrigin;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestOrigin.js.map