var app;
(function (app) {
    var domain;
    (function (domain) {
        var CustomFieldSelectListItem = (function () {
            function CustomFieldSelectListItem(CustomFieldSelectListItemID, CustomFieldTypeID, CustomFieldSelectListItemLabel, CustomFieldSelectListItemValue, ListSequence, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.CustomFieldSelectListItemID = CustomFieldSelectListItemID;
                this.CustomFieldTypeID = CustomFieldTypeID;
                this.CustomFieldSelectListItemLabel = CustomFieldSelectListItemLabel;
                this.CustomFieldSelectListItemValue = CustomFieldSelectListItemValue;
                this.ListSequence = ListSequence;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return CustomFieldSelectListItem;
        }());
        domain.CustomFieldSelectListItem = CustomFieldSelectListItem;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=customFieldSelectListItem.js.map