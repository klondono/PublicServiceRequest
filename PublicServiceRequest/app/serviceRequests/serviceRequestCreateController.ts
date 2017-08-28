module app.serviceRequest {

    interface IServiceRequestCreateModel {
        //define properties and methods you intend to expose to the view here
    }

    //$stateParams is used when we need to get parameter from URL
    interface IServiceRequestCreateModelParams extends ng.ui.IStateParamsService {

        //input parameters here ex: Id : String;
        //ownerGroupID: string;
    }

    //define class (aka controller) that implements interface
    export class ServiceRequestCreateController implements IServiceRequestCreateModel {
        
        //inject dependencies, must be in same order as in the constructor
        static $inject = ['serviceTypeOwnerGroupListResolved','serviceTypeSearchSharingService'];

        //constructor: include properties to be exposed when class is instantiated including injected dependencies
        constructor(private serviceTypeOwnerGroupListResolved: app.domain.IServiceTypeOwnerGroup[], private serviceTypeSearchSharingService : app.common.ServiceTypeSearchSharingService) {
            //methods to be executed immediately 
            //serviceTypeOwnerGroupListResolved is resolved in ui-router and injected into constructor
            
            //reset dropdown lists to null
            this.serviceTypeSearchSharingService.ServiceTypeOwnerGroupID = null;
            this.serviceTypeSearchSharingService.ServiceTypeID = null;
        }
        //controller methods
    }
    //register controller with the main angular module defined in app.ts
    angular
        .module('serviceRequestApp').
        controller("ServiceRequestCreateController", ServiceRequestCreateController);

}