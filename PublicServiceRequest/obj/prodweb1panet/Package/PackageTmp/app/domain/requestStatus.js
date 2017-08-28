var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestStatus = (function () {
            function RequestStatus(RequestStatusID, RequestStatusName, RequestStatusDescription, RequestStatusColor, StatusReopensRequestFlag, StatusClosesRequestFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.RequestStatusID = RequestStatusID;
                this.RequestStatusName = RequestStatusName;
                this.RequestStatusDescription = RequestStatusDescription;
                this.RequestStatusColor = RequestStatusColor;
                this.StatusReopensRequestFlag = StatusReopensRequestFlag;
                this.StatusClosesRequestFlag = StatusClosesRequestFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return RequestStatus;
        }());
        domain.RequestStatus = RequestStatus;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestStatus.js.map