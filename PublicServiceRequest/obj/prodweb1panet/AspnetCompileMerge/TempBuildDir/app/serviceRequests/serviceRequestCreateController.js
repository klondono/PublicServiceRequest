var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestCreateController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestCreateController(serviceTypeOwnerGroupListResolved, serviceTypeSearchSharingService) {
                //methods to be executed immediately 
                //serviceTypeOwnerGroupListResolved is resolved in ui-router and injected into constructor
                this.serviceTypeOwnerGroupListResolved = serviceTypeOwnerGroupListResolved;
                this.serviceTypeSearchSharingService = serviceTypeSearchSharingService;
                //reset dropdown lists to null
                this.serviceTypeSearchSharingService.ServiceTypeOwnerGroupID = null;
                this.serviceTypeSearchSharingService.ServiceTypeID = null;
            }
            return ServiceRequestCreateController;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestCreateController.$inject = ['serviceTypeOwnerGroupListResolved', 'serviceTypeSearchSharingService'];
        serviceRequest.ServiceRequestCreateController = ServiceRequestCreateController;
        //register controller with the main angular module defined in app.ts
        angular
            .module('serviceRequestApp').
            controller("ServiceRequestCreateController", ServiceRequestCreateController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestCreateController.js.map