var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestPriority = (function () {
            function RequestPriority(RequestPriorityID, RequestPriorityName, RequestPriorityDescription, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.RequestPriorityID = RequestPriorityID;
                this.RequestPriorityName = RequestPriorityName;
                this.RequestPriorityDescription = RequestPriorityDescription;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return RequestPriority;
        }());
        domain.RequestPriority = RequestPriority;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestPriority.js.map