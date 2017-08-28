var app;
(function (app) {
    var domain;
    (function (domain) {
        var CustomFieldType = (function () {
            function CustomFieldType(CustomFieldTypeID, CustomFieldTypeName, CustomFieldTypeDescription, AllowEditFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.CustomFieldTypeID = CustomFieldTypeID;
                this.CustomFieldTypeName = CustomFieldTypeName;
                this.CustomFieldTypeDescription = CustomFieldTypeDescription;
                this.AllowEditFlag = AllowEditFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return CustomFieldType;
        }());
        domain.CustomFieldType = CustomFieldType;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=customFieldType.js.map