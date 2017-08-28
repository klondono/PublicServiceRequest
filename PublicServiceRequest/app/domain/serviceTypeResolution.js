var app;
(function (app) {
    var domain;
    (function (domain) {
        var ServiceTypeResolution = (function () {
            function ServiceTypeResolution(ServiceTypeResolutionID, ServiceTypeResolutionName, ServiceTypeResolutionDescription, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.ServiceTypeResolutionID = ServiceTypeResolutionID;
                this.ServiceTypeResolutionName = ServiceTypeResolutionName;
                this.ServiceTypeResolutionDescription = ServiceTypeResolutionDescription;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return ServiceTypeResolution;
        }());
        domain.ServiceTypeResolution = ServiceTypeResolution;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceTypeResolution.js.map