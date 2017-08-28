var app;
(function (app) {
    var domain;
    (function (domain) {
        var SearchStatusViewModel = (function () {
            function SearchStatusViewModel(StatusValue, StatusName) {
                this.StatusValue = StatusValue;
                this.StatusName = StatusName;
            }
            return SearchStatusViewModel;
        }());
        domain.SearchStatusViewModel = SearchStatusViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=searchStatusViewModel.js.map