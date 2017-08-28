var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestAction = (function () {
            function RequestAction(RequestActionID, RequestActionTypeID, RequestID, RequestStatusChangedID, RequestAssignedUserID, Comments, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.RequestActionID = RequestActionID;
                this.RequestActionTypeID = RequestActionTypeID;
                this.RequestID = RequestID;
                this.RequestStatusChangedID = RequestStatusChangedID;
                this.RequestAssignedUserID = RequestAssignedUserID;
                this.Comments = Comments;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return RequestAction;
        }());
        domain.RequestAction = RequestAction;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestAction.js.map