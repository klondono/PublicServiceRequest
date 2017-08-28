var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestOwnerGroupViewModel = (function () {
            function RequestOwnerGroupViewModel(OwnerGroupID, OwnerGroupName, Email) {
                this.OwnerGroupID = OwnerGroupID;
                this.OwnerGroupName = OwnerGroupName;
                this.Email = Email;
            }
            return RequestOwnerGroupViewModel;
        }());
        domain.RequestOwnerGroupViewModel = RequestOwnerGroupViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestOwnerGroupViewModel.js.map