var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestSearchResultController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestSearchResultController($stateParams, dataAccessService, serviceTypeSearchSharingService, $state) {
                this.$stateParams = $stateParams;
                this.dataAccessService = dataAccessService;
                this.serviceTypeSearchSharingService = serviceTypeSearchSharingService;
                this.$state = $state;
                //methods to be executed immediately
                this.ServiceTypeKeywordSearch($stateParams, dataAccessService);
            }
            //controller methods
            ServiceRequestSearchResultController.prototype.ServiceTypeKeywordSearch = function ($stateParams, dataAccessService) {
                var _this = this;
                //reset dropdown list values to null
                this.serviceTypeSearchSharingService.ServiceTypeOwnerGroupID = null;
                this.serviceTypeSearchSharingService.ServiceTypeID = null;
                //build query
                if ($stateParams.Criteria) {
                    var $select = "?$select=ServiceTypeID,ServiceTypeName,ServiceTypeDescription,ServiceTypeOwnerGroup/ServiceTypeOwnerGroupName,ServiceTypeOwnerGroup/ServiceTypeOwnerGroupID";
                    var $expand = "&$expand=ServiceTypeOwnerGroup,ServiceTypeSearchKeywordLinks/ServiceTypeSearchKeyword";
                    var $criteria = "&$filter=(ServiceTypeShowAsStandaloneServiceFlag eq true) and (AdmIsActive eq 'Y') and (ServiceTypeOwnerGroup/AdmIsActive eq \'Y\') and (ServiceTypeOwnerGroup/SelectableOnRequestCreationFlag eq true) and (substringof('" + $stateParams.Criteria + "', ServiceTypeName) or substringof('" + $stateParams.Criteria + "', ServiceTypeDescription) or ServiceTypeSearchKeywordLinks/any(c : c/ServiceTypeSearchKeyword/ServiceTypeSearchKeywordName eq '" + $stateParams.Criteria + "'))";
                    var $orderby = "&$orderby=ServiceTypeName";
                    this.serviceTypeResource = dataAccessService.getServiceTypeResource($select + $expand + $criteria + $orderby);
                    this.serviceTypeResource.getServiceTypeList(function (data) {
                        _this.serviceTypes = data;
                    });
                }
            };
            return ServiceRequestSearchResultController;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestSearchResultController.$inject = ['$stateParams', 'dataAccessService', 'serviceTypeSearchSharingService'];
        //register controller with the main angular module defined in app.ts
        angular.module('serviceRequestApp')
            .controller('ServiceRequestSearchResultController', ServiceRequestSearchResultController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestSearchResultController.js.map