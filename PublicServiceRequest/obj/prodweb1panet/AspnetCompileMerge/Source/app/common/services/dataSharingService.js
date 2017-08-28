var app;
(function (app) {
    var common;
    (function (common) {
        //define class (aka service) that implements interface
        var DataSharingService = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function DataSharingService(dataAccessService) {
                this.dataAccessService = dataAccessService;
            }
            ;
            //service methods
            DataSharingService.prototype.getAssociatedServiceTypes = function (parentServiceTypeID) {
                var _this = this;
                //custom odata action GetAssociatedServiceTypes defined in webapi config
                var associatedServiceTypeResource = this.dataAccessService.getAssociatedServiceTypeResource('GetAssociatedServiceTypes/');
                var newAssociatedServiceTypeResource = new associatedServiceTypeResource();
                newAssociatedServiceTypeResource.$get({ id: parentServiceTypeID }, function (data) { _this.associatedServiceTypeViewModel = data; }, function (error) { console.log(error); });
            };
            //method searches for custom fields that match the serviceType checked or unchecked and show hides corresponding field
            DataSharingService.prototype.toggleServiceType = function (serviceTypeID, serviceTypeChildCheckedByDefaultFlag) {
                for (var i = 0; i < this.associatedServiceTypeViewModel.CustomFields.length; i++) {
                    if (this.associatedServiceTypeViewModel.CustomFields[i].ServiceTypeID == serviceTypeID) {
                        this.associatedServiceTypeViewModel.CustomFields[i].ServiceTypeChildCheckedByDefaultFlag = serviceTypeChildCheckedByDefaultFlag;
                        //important to reset values to null so that ng-pattern validation ignores fields that are hidden
                        this.associatedServiceTypeViewModel.CustomFields[i].DisplayData = null;
                        this.associatedServiceTypeViewModel.CustomFields[i].FieldValue = null;
                    }
                    ;
                }
            };
            return DataSharingService;
        }());
        //inject dependencies, must be in same order as in the constructor
        DataSharingService.$inject = ['dataAccessService'];
        common.DataSharingService = DataSharingService;
        angular.module("common.services")
            .service('dataSharingService', DataSharingService);
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=dataSharingService.js.map