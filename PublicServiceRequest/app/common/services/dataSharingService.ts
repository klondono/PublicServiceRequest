module app.common {

    interface IDataSharingService {
        //define properties and methods you intend to expose to the view(s) here
        associatedServiceTypeViewModel: app.domain.IAssociatedServiceTypeContainerViewModel;
        getAssociatedServiceTypes(parentServiceTypeID: number): void;
        toggleServiceType(serviceTypeID: number, serviceTypeChildCheckedByDefaultFlag: boolean): void
    }
    //define class (aka service) that implements interface
    export class DataSharingService
        implements IDataSharingService {
        //declare properties for class
        associatedServiceTypeViewModel: app.domain.IAssociatedServiceTypeContainerViewModel;
        //inject dependencies, must be in same order as in the constructor
        static $inject = ['dataAccessService'];

        //constructor: include properties to be exposed when class is instantiated including injected dependencies
        constructor(private dataAccessService: DataAccessService) { };

        //service methods
        getAssociatedServiceTypes(parentServiceTypeID: number): void {

            //custom odata action GetAssociatedServiceTypes defined in webapi config
            var associatedServiceTypeResource = this.dataAccessService.getAssociatedServiceTypeResource('GetAssociatedServiceTypes/');
            var newAssociatedServiceTypeResource = new associatedServiceTypeResource();
            newAssociatedServiceTypeResource.$get({ id: parentServiceTypeID }, (data: app.domain.IAssociatedServiceTypeContainerViewModel) => { this.associatedServiceTypeViewModel = data;}, (error: any) => { console.log(error); });
        }

        //method searches for custom fields that match the serviceType checked or unchecked and show hides corresponding field
        toggleServiceType(serviceTypeID: number, serviceTypeChildCheckedByDefaultFlag: boolean):void {

             for (var i = 0; i < this.associatedServiceTypeViewModel.CustomFields.length; i++) {

                if (this.associatedServiceTypeViewModel.CustomFields[i].ServiceTypeID == serviceTypeID) {
                    this.associatedServiceTypeViewModel.CustomFields[i].ServiceTypeChildCheckedByDefaultFlag = serviceTypeChildCheckedByDefaultFlag;
                    //important to reset values to null so that ng-pattern validation ignores fields that are hidden
                    this.associatedServiceTypeViewModel.CustomFields[i].DisplayData = null;
                    this.associatedServiceTypeViewModel.CustomFields[i].FieldValue = null;
                };

            }
        }
    }

    angular.module("common.services")
        .service('dataSharingService', DataSharingService);
}