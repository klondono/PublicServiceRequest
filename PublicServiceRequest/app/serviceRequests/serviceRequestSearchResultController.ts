module app.serviceRequest {
    interface IServiceRequestSearchResultModel {
        //define properties you intend to expose to the view here
        serviceTypes: app.domain.IServiceType[];
        ServiceTypeKeywordSearch($stateParams: IServiceRequestSearchResultParams, dataAccessService: app.common.DataAccessService): void;
    }

    //$stateParams is used when we need to get parameter from URL
    interface IServiceRequestSearchResultParams extends ng.ui.IStateParamsService {
        //input parameters here ex: Id : String;
        Criteria: string;
    }
    //define class (aka controller) that implements interface
    class ServiceRequestSearchResultController implements IServiceRequestSearchResultModel {
        
        //declare properties for class
        serviceTypes: app.domain.IServiceType[];
        serviceTypeResource: common.IServiceTypeResource;

        //inject dependencies, must be in same order as in the constructor
        static $inject = ['$stateParams', 'dataAccessService', 'serviceTypeSearchSharingService'];

        //constructor: include properties to be exposed when class is instantiated including injected dependencies
        constructor(private $stateParams: IServiceRequestSearchResultParams, private dataAccessService: app.common.DataAccessService,
            private serviceTypeSearchSharingService: app.common.ServiceTypeSearchSharingService , private $state: ng.ui.IStateService) {

            //methods to be executed immediately
            this.ServiceTypeKeywordSearch($stateParams, dataAccessService);
        }

        //controller methods
        ServiceTypeKeywordSearch($stateParams: IServiceRequestSearchResultParams, dataAccessService: app.common.DataAccessService): void {
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
                this.serviceTypeResource.getServiceTypeList((data: app.domain.IServiceType[]) => {
                    this.serviceTypes = data;
                }); 
            }
        }
    }
    //register controller with the main angular module defined in app.ts
    angular.module('serviceRequestApp')
        .controller('ServiceRequestSearchResultController', ServiceRequestSearchResultController);
}