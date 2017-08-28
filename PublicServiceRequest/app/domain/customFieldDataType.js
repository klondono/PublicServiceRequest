var app;
(function (app) {
    var domain;
    (function (domain) {
        var CustomFieldDataType = (function () {
            function CustomFieldDataType(CustomFieldDataTypeID, CustomFieldDataTypeName, CustomFieldDataTypeDescription, RegularExpression, ErrorMessage, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.CustomFieldDataTypeID = CustomFieldDataTypeID;
                this.CustomFieldDataTypeName = CustomFieldDataTypeName;
                this.CustomFieldDataTypeDescription = CustomFieldDataTypeDescription;
                this.RegularExpression = RegularExpression;
                this.ErrorMessage = ErrorMessage;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return CustomFieldDataType;
        }());
        domain.CustomFieldDataType = CustomFieldDataType;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=customFieldDataType.js.map