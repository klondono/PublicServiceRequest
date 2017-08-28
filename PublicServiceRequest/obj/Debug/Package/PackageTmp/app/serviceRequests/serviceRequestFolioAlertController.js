var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestFolioAlertController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestFolioAlertController($uibModalInstance, folioList, requestFoliosResolved, folioResolved, $state) {
                this.$uibModalInstance = $uibModalInstance;
                this.folioList = folioList;
                this.requestFoliosResolved = requestFoliosResolved;
                this.folioResolved = folioResolved;
                this.$state = $state;
            }
            ;
            ServiceRequestFolioAlertController.prototype.Cancel = function () {
                this.$uibModalInstance.dismiss('cancel');
            };
            ;
            //close modal instance and return newly updated model to parent window
            ServiceRequestFolioAlertController.prototype.AddFolio = function () {
                var newFolio = {
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
            };
            ServiceRequestFolioAlertController.prototype.GoToRequestWorkspace = function (requestID) {
                this.$state.go('Workspace', { 'Id': requestID });
                this.$uibModalInstance.dismiss('cancel');
            };
            return ServiceRequestFolioAlertController;
        }());
        //declare properties for class
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestFolioAlertController.$inject = ['$uibModalInstance', 'folioList', 'requestFoliosResolved', 'folioResolved', '$state'];
        //register controller with the main angular module defined in app.ts
        angular
            .module('serviceRequestApp').
            controller("ServiceRequestFolioAlertController", ServiceRequestFolioAlertController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestFolioAlertController.js.map