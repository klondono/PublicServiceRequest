var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestFolioType = (function () {
            function RequestFolioType(RequestFolioTypeID, RequestFolioTypeName, RequestFoliotypeDescription, AdmIsActive, AdmUserAddedFullName, AdmUserAdded, AdmDateAdded, AdmUserModifiedFullName, AdmUserModified, AdmDateModified) {
                this.RequestFolioTypeID = RequestFolioTypeID;
                this.RequestFolioTypeName = RequestFolioTypeName;
                this.RequestFoliotypeDescription = RequestFoliotypeDescription;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmUserModified = AdmUserModified;
                this.AdmDateModified = AdmDateModified;
            }
            return RequestFolioType;
        }());
        domain.RequestFolioType = RequestFolioType;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestFolioType.js.map