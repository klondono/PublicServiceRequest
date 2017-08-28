module app.common {

    interface IServiceTypeSearchSharingService {
        //define properties and methods you intend to expose to the view(s) here
        ServiceTypeOwnerGroupID: number;
        ServiceTypeID: number;
        serviceTypes: app.domain.IServiceType[];
    }
    //define class (aka service) that implements interface
    export class ServiceTypeSearchSharingService
        implements IServiceTypeSearchSharingService {
        //declare properties for class
        ServiceTypeOwnerGroupID: number = null;
        ServiceTypeID: number = null;
        serviceTypes: app.domain.IServiceType[];

        //inject dependencies, must be in same order as in the constructor
        static $inject = ['dataAccessService', '$state'];

        //constructor: include properties to be exposed when class is instantiated including injected dependencies
        constructor(private dataAccessService: app.common.DataAccessService, private $state: ng.ui.IStateService) {

        }
        //service methods
        GetServiceTypesForOwnerGroup(): void {
            //if id has value then get related service types for owner group
            if (this.ServiceTypeOwnerGroupID) {

                var serviceTypeResource = this.dataAccessService.getServiceTypeResource('');
                serviceTypeResource.getServiceTypesByOwnerGroup({ id: this.ServiceTypeOwnerGroupID }, (data: app.domain.IServiceType[]) => {
                    this.serviceTypes = data;
                });
            }
            else {

                this.ServiceTypeID = null;
                this.$state.go('ServiceRequest');
                
            }
        }
        //method is called when user clicks on service type from in search for services textbox
        GoToCreateServiceRequestView(serviceTypeID: number, serviceTypeOwnerGroupID: number): void {
            
            //set the values for the dropdown boxes in serviceRequestCreateView.html to match selected servicetype from search results
            this.ServiceTypeOwnerGroupID = serviceTypeOwnerGroupID;
            this.GetServiceTypesForOwnerGroup();
            this.ServiceTypeID = serviceTypeID;
            //go to selected servicetype request form
            this.$state.go('ServiceRequest.RequestForm', { Id: serviceTypeID });
        }

        GoToServiceRequestFormView(): void {
            //executes on servicetype selectbox change, if no servicetypeid then go back to ServiceRequest ui-router state
            if (this.ServiceTypeID) {
                this.$state.go('ServiceRequest.RequestForm', { Id: this.ServiceTypeID });
            }
            else {

                this.$state.go('ServiceRequest');
            }
        }

    }
    angular.module("common.services")
        .service('serviceTypeSearchSharingService', ServiceTypeSearchSharingService);
}