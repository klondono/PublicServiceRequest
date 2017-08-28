var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestListController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestListController(dataSharingService, $stateParams) {
                this.dataSharingService = dataSharingService;
                this.$stateParams = $stateParams;
                dataSharingService.getAssociatedServiceTypes($stateParams.Id);
            }
            return ServiceRequestListController;
        }());
        //declare properties for class
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestListController.$inject = ['dataSharingService', '$stateParams', '$scope'];
        //register controller with the main angular module defined in app.ts
        angular.module('serviceRequestApp')
            .controller('ServiceRequestListController', ServiceRequestListController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestListController.js.map