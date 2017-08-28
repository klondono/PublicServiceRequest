var app;
(function (app) {
    var common;
    (function (common) {
        //define class (aka service) that implements interface
        var ServiceTypeSearchSharingService = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceTypeSearchSharingService(dataAccessService, $state) {
                this.dataAccessService = dataAccessService;
                this.$state = $state;
                //declare properties for class
                this.ServiceTypeOwnerGroupID = null;
                this.ServiceTypeID = null;
            }
            //service methods
            ServiceTypeSearchSharingService.prototype.GetServiceTypesForOwnerGroup = function () {
                var _this = this;
                //if id has value then get related service types for owner group
                if (this.ServiceTypeOwnerGroupID) {
                    var serviceTypeResource = this.dataAccessService.getServiceTypeResource('');
                    serviceTypeResource.getServiceTypesByOwnerGroup({ id: this.ServiceTypeOwnerGroupID }, function (data) {
                        _this.serviceTypes = data;
                    });
                }
                else {
                    this.ServiceTypeID = null;
                    this.$state.go('ServiceRequest');
                }
            };
            //method is called when user clicks on service type from in search for services textbox
            ServiceTypeSearchSharingService.prototype.GoToCreateServiceRequestView = function (serviceTypeID, serviceTypeOwnerGroupID) {
                //set the values for the dropdown boxes in serviceRequestCreateView.html to match selected servicetype from search results
                this.ServiceTypeOwnerGroupID = serviceTypeOwnerGroupID;
                this.GetServiceTypesForOwnerGroup();
                this.ServiceTypeID = serviceTypeID;
                //go to selected servicetype request form
                this.$state.go('ServiceRequest.RequestForm', { Id: serviceTypeID });
            };
            ServiceTypeSearchSharingService.prototype.GoToServiceRequestFormView = function () {
                //executes on servicetype selectbox change, if no servicetypeid then go back to ServiceRequest ui-router state
                if (this.ServiceTypeID) {
                    this.$state.go('ServiceRequest.RequestForm', { Id: this.ServiceTypeID });
                }
                else {
                    this.$state.go('ServiceRequest');
                }
            };
            return ServiceTypeSearchSharingService;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceTypeSearchSharingService.$inject = ['dataAccessService', '$state'];
        common.ServiceTypeSearchSharingService = ServiceTypeSearchSharingService;
        angular.module("common.services")
            .service('serviceTypeSearchSharingService', ServiceTypeSearchSharingService);
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceTypeSearchSharingService.js.map