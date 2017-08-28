var app;
(function (app) {
    var domain;
    (function (domain) {
        var CustomFieldViewModel = (function () {
            function CustomFieldViewModel(ServiceTypeCustomFieldTransactionID, CustomFieldLabel, CustomFieldValue) {
                this.ServiceTypeCustomFieldTransactionID = ServiceTypeCustomFieldTransactionID;
                this.CustomFieldLabel = CustomFieldLabel;
                this.CustomFieldValue = CustomFieldValue;
            }
            return CustomFieldViewModel;
        }());
        domain.CustomFieldViewModel = CustomFieldViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=customFieldViewModel.js.map