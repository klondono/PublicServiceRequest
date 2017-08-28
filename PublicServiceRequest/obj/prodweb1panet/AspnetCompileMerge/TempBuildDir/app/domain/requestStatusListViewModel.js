var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestStatusListViewModel = (function () {
            function RequestStatusListViewModel(StatusValue, StatusName, StatusOpensRequest, StatusClosesRequest) {
                this.StatusValue = StatusValue;
                this.StatusName = StatusName;
                this.StatusOpensRequest = StatusOpensRequest;
                this.StatusClosesRequest = StatusClosesRequest;
            }
            return RequestStatusListViewModel;
        }());
        domain.RequestStatusListViewModel = RequestStatusListViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestStatusListViewModel.js.map