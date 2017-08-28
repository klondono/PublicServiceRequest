var app;
(function (app) {
    var domain;
    (function (domain) {
        var ServiceType = (function () {
            function ServiceType(ServiceTypeID, ServiceTypeOwnerGroupID, DefaultRequestStatusID, EscalationExpectedStatusID, ServiceTypeNumber, ServiceTypeName, ServiceTypeDescription, ServiceTypeDefaultDuration, ServiceTypeAssigneeDependantOnPropertyFlag, ServiceTypeIncludePropertyInfoFlag, ServiceTypeIncludeFirstActionCommentFlag, ServiceTypeShowAsStandaloneServiceFlag, ServiceTypeParentClosesWhenChildrenClosedFlag, ServiceTypeConcurrentCreationOfChildrenFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.ServiceTypeID = ServiceTypeID;
                this.ServiceTypeOwnerGroupID = ServiceTypeOwnerGroupID;
                this.DefaultRequestStatusID = DefaultRequestStatusID;
                this.EscalationExpectedStatusID = EscalationExpectedStatusID;
                this.ServiceTypeNumber = ServiceTypeNumber;
                this.ServiceTypeName = ServiceTypeName;
                this.ServiceTypeDescription = ServiceTypeDescription;
                this.ServiceTypeDefaultDuration = ServiceTypeDefaultDuration;
                this.ServiceTypeAssigneeDependantOnPropertyFlag = ServiceTypeAssigneeDependantOnPropertyFlag;
                this.ServiceTypeIncludePropertyInfoFlag = ServiceTypeIncludePropertyInfoFlag;
                this.ServiceTypeIncludeFirstActionCommentFlag = ServiceTypeIncludeFirstActionCommentFlag;
                this.ServiceTypeShowAsStandaloneServiceFlag = ServiceTypeShowAsStandaloneServiceFlag;
                this.ServiceTypeParentClosesWhenChildrenClosedFlag = ServiceTypeParentClosesWhenChildrenClosedFlag;
                this.ServiceTypeConcurrentCreationOfChildrenFlag = ServiceTypeConcurrentCreationOfChildrenFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return ServiceType;
        }());
        domain.ServiceType = ServiceType;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceType.js.map