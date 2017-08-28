var app;
(function (app) {
    var domain;
    (function (domain) {
        var AssociatedServiceTypeContainerViewModel = (function () {
            function AssociatedServiceTypeContainerViewModel(AssociatedServiceTypes, CustomFields) {
                this.AssociatedServiceTypes = AssociatedServiceTypes;
                this.CustomFields = CustomFields;
            }
            return AssociatedServiceTypeContainerViewModel;
        }());
        domain.AssociatedServiceTypeContainerViewModel = AssociatedServiceTypeContainerViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=associatedServiceTypeContainerViewModel.js.map