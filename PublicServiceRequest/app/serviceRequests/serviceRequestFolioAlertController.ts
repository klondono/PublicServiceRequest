module app.serviceRequest {
    interface IServiceRequestFolioAlertController {
        //define properties you intend to expose to the view here
    }
    //define class (aka controller) that implements interface
    class ServiceRequestFolioAlertController implements IServiceRequestFolioAlertController {
        //declare properties for class

        //inject dependencies, must be in same order as in the constructor
        static $inject = ['$uibModalInstance', 'folioList', 'requestFoliosResolved', 'folioResolved','$state'];

        //constructor: include properties to be exposed when class is instantiated including injected dependencies
        constructor(private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance, private folioList: app.domain.IRequestFolio[], private requestFoliosResolved: app.domain.IRequestFolioAlertViewModel, private folioResolved: app.domain.IRequestFolio, private $state: ng.ui.IStateService) {
        };

        Cancel():void {
            this.$uibModalInstance.dismiss('cancel');
        };

        //close modal instance and return newly updated model to parent window
        AddFolio(): void {

                var newFolio: app.domain.IRequestFolio = {
                    RequestFolioID: 0,
                    RequestFolioTypeID: this.folioResolved.RequestFolioTypeID,
                    Folio: this.folioResolved.Folio,
                    FormattedFolio: this.folioResolved.FormattedFolio,
                    Confidential: this.folioResolved.Confidential,
                    Cancelled: this.folioResolved.Cancelled,
                    HasOpenPSR: this.folioResolved.HasOpenPSR,
                    District: this.folioResolved.District,
                    RequestID: null,
                    Year: this.folioResolved.Year,
                    HistoryRunID: this.folioResolved.HistoryRunID,
                    DORCode: this.folioResolved.DORCode,
                    Owner: this.folioResolved.Owner,
                    SiteAddress: this.folioResolved.SiteAddress,
                    SiteCity: this.folioResolved.SiteCity,
                    ZipCode: this.folioResolved.ZipCode,
                    MailingAddress: null,
                    MailingCity: null,
                    MailingZipCode: null,
                    AdmIsActive: null,
                    AdmUserAdded: null,
                    AdmUserAddedFullName: null,
                    AdmDateAdded: null,
                    AdmUserModified: null,
                    AdmUserModifiedFullName: null,
                    AdmDateModified: null
                };

                this.folioList.push(newFolio);
                this.$uibModalInstance.close(this.folioList);      
        }

        GoToRequestWorkspace(requestID: number): void {
            this.$state.go('Workspace', { 'Id': requestID });
            this.$uibModalInstance.dismiss('cancel');
        }
    }
    //register controller with the main angular module defined in app.ts
    angular
        .module('serviceRequestApp').
        controller("ServiceRequestFolioAlertController", ServiceRequestFolioAlertController);
}