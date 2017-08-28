var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestActionType = (function () {
            function RequestActionType(RequestActionTypeID, RequestActionTypeName, RequestActionTypeDescription, BackgroundColor, TextColor, ChangeRequestStatusFlag, ReassignRequestFlag, DisplayFlag, SystemReservedFlag, AllowReplicationFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.RequestActionTypeID = RequestActionTypeID;
                this.RequestActionTypeName = RequestActionTypeName;
                this.RequestActionTypeDescription = RequestActionTypeDescription;
                this.BackgroundColor = BackgroundColor;
                this.TextColor = TextColor;
                this.ChangeRequestStatusFlag = ChangeRequestStatusFlag;
                this.ReassignRequestFlag = ReassignRequestFlag;
                this.DisplayFlag = DisplayFlag;
                this.SystemReservedFlag = SystemReservedFlag;
                this.AllowReplicationFlag = AllowReplicationFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return RequestActionType;
        }());
        domain.RequestActionType = RequestActionType;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestActionType.js.map