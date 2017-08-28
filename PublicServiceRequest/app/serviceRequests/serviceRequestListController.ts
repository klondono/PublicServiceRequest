module app.serviceRequest {
    interface IServiceRequestListModel {
        //define properties you intend to expose to the view here
    }
    //$stateParams is used when we need to get parameter from URL
    interface IServiceRequestListStateParams extends ng.ui.IStateParamsService {
        Id: number;
    }
    //define class (aka controller) that implements interface
    class ServiceRequestListController implements IServiceRequestListModel {
        //declare properties for class
        //inject dependencies, must be in same order as in the constructor
        static $inject = ['dataSharingService', '$stateParams','$scope'];

        //constructor: include properties to be exposed when class is instantiated including injected dependencies
        constructor(private dataSharingService: app.common.DataSharingService, private $stateParams: IServiceRequestListStateParams) {
            dataSharingService.getAssociatedServiceTypes($stateParams.Id);
        }
    }
    //register controller with the main angular module defined in app.ts
    angular.module('serviceRequestApp')
        .controller('ServiceRequestListController', ServiceRequestListController);
}