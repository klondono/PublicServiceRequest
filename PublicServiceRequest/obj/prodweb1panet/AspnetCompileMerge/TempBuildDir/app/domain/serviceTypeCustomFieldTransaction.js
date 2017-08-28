var app;
(function (app) {
    var domain;
    (function (domain) {
        var ServiceTypeCustomFieldTransaction = (function () {
            function ServiceTypeCustomFieldTransaction(ServiceTypeCustomFieldTransactionID, RequestID, ServiceTypeCustomFieldID, DisplayData, Value, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified) {
                this.ServiceTypeCustomFieldTransactionID = ServiceTypeCustomFieldTransactionID;
                this.RequestID = RequestID;
                this.ServiceTypeCustomFieldID = ServiceTypeCustomFieldID;
                this.DisplayData = DisplayData;
                this.Value = Value;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
            }
            return ServiceTypeCustomFieldTransaction;
        }());
        domain.ServiceTypeCustomFieldTransaction = ServiceTypeCustomFieldTransaction;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceTypeCustomFieldTransaction.js.map