var app;
(function (app) {
    var domain;
    (function (domain) {
        var VMServiceType = (function () {
            function VMServiceType(ServiceTypeID, ServiceTypeOwnerGroupID, DefaultRequestStatusID, EscalationExpectedStatusID, ServiceTypeNumber, ServiceTypeName, ServiceTypeDescription, ServiceTypeDefaultDuration, ServiceTypeNotificationEmail, ServiceTypeEscalationEmail, ServiceTypeAssigneeDependantOnPropertyFlag, ServiceTypeIncludePropertyInfoFlag, ServiceTypeIncludeFirstActionCommentFlag, ServiceTypeShowAsStandaloneServiceFlag, ServiceTypeParentClosesWhenChildrenClosedFlag, ServiceTypeChildRequiredFlag, ServiceTypeChildCheckedByDefaultFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified, ServiceTypeCustomFields, value) {
                this.ServiceTypeID = ServiceTypeID;
                this.ServiceTypeOwnerGroupID = ServiceTypeOwnerGroupID;
                this.DefaultRequestStatusID = DefaultRequestStatusID;
                this.EscalationExpectedStatusID = EscalationExpectedStatusID;
                this.ServiceTypeNumber = ServiceTypeNumber;
                this.ServiceTypeName = ServiceTypeName;
                this.ServiceTypeDescription = ServiceTypeDescription;
                this.ServiceTypeDefaultDuration = ServiceTypeDefaultDuration;
                this.ServiceTypeNotificationEmail = ServiceTypeNotificationEmail;
                this.ServiceTypeEscalationEmail = ServiceTypeEscalationEmail;
                this.ServiceTypeAssigneeDependantOnPropertyFlag = ServiceTypeAssigneeDependantOnPropertyFlag;
                this.ServiceTypeIncludePropertyInfoFlag = ServiceTypeIncludePropertyInfoFlag;
                this.ServiceTypeIncludeFirstActionCommentFlag = ServiceTypeIncludeFirstActionCommentFlag;
                this.ServiceTypeShowAsStandaloneServiceFlag = ServiceTypeShowAsStandaloneServiceFlag;
                this.ServiceTypeParentClosesWhenChildrenClosedFlag = ServiceTypeParentClosesWhenChildrenClosedFlag;
                this.ServiceTypeChildRequiredFlag = ServiceTypeChildRequiredFlag;
                this.ServiceTypeChildCheckedByDefaultFlag = ServiceTypeChildCheckedByDefaultFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
                this.ServiceTypeCustomFields = ServiceTypeCustomFields;
                this.value = value;
            }
            return VMServiceType;
        }());
        domain.VMServiceType = VMServiceType;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=VMServiceType.js.map