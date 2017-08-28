var app;
(function (app) {
    var domain;
    (function (domain) {
        var ServiceTypeViewModel = (function () {
            function ServiceTypeViewModel(ServiceTypeID, ServiceTypeName, ServiceTypeCompositeName, ServiceTypeOwnerGroupName) {
                this.ServiceTypeID = ServiceTypeID;
                this.ServiceTypeName = ServiceTypeName;
                this.ServiceTypeCompositeName = ServiceTypeCompositeName;
                this.ServiceTypeOwnerGroupName = ServiceTypeOwnerGroupName;
            }
            return ServiceTypeViewModel;
        }());
        domain.ServiceTypeViewModel = ServiceTypeViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceTypeViewModel.js.map