var app;
(function (app) {
    var domain;
    (function (domain) {
        var MyDashboardViewModel = (function () {
            function MyDashboardViewModel(StatOne, StatTwo, StatThree, StatFour) {
                this.StatOne = StatOne;
                this.StatTwo = StatTwo;
                this.StatThree = StatThree;
                this.StatFour = StatFour;
            }
            return MyDashboardViewModel;
        }());
        domain.MyDashboardViewModel = MyDashboardViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=myDashboardViewModel.js.map