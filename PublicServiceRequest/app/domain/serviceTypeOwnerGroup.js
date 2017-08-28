var app;
(function (app) {
    var domain;
    (function (domain) {
        var ServiceTypeOwnerGroup = (function () {
            function ServiceTypeOwnerGroup(ServiceTypeOwnerGroupID, ServiceTypeOwnerGroupLocationID, ServiceTypeOwnerGroupName, ServiceTypeOwnerGroupDescription, ServiceTypeOwnerGroupPhoneNo, ServiceTypeOwnerGroupDistrictNo, ServiceTypeOwnerGroupNotificationEmail, ServiceTypeOwnerGroupEscalationEmail, ServiceTypeOwnerGroupMainEmail, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.ServiceTypeOwnerGroupID = ServiceTypeOwnerGroupID;
                this.ServiceTypeOwnerGroupLocationID = ServiceTypeOwnerGroupLocationID;
                this.ServiceTypeOwnerGroupName = ServiceTypeOwnerGroupName;
                this.ServiceTypeOwnerGroupDescription = ServiceTypeOwnerGroupDescription;
                this.ServiceTypeOwnerGroupPhoneNo = ServiceTypeOwnerGroupPhoneNo;
                this.ServiceTypeOwnerGroupDistrictNo = ServiceTypeOwnerGroupDistrictNo;
                this.ServiceTypeOwnerGroupNotificationEmail = ServiceTypeOwnerGroupNotificationEmail;
                this.ServiceTypeOwnerGroupEscalationEmail = ServiceTypeOwnerGroupEscalationEmail;
                this.ServiceTypeOwnerGroupMainEmail = ServiceTypeOwnerGroupMainEmail;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return ServiceTypeOwnerGroup;
        }());
        domain.ServiceTypeOwnerGroup = ServiceTypeOwnerGroup;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceTypeOwnerGroup.js.map