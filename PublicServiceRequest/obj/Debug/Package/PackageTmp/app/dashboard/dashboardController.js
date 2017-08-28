var app;
(function (app) {
    var dashboard;
    (function (dashboard) {
        var DashboardController = (function () {
            //declare properties for class
            //inject dependencies, must be in same order as in the constructor
            //static $inject = ['dataAccessService'];
            function DashboardController(dataAccessService) {
                this.dataAccessService = dataAccessService;
            }
            return DashboardController;
        }());
        angular.module('serviceRequestApp')
            .controller('DashboardController', DashboardController);
    })(dashboard = app.dashboard || (app.dashboard = {}));
})(app || (app = {}));
//# sourceMappingURL=dashboardController.js.map