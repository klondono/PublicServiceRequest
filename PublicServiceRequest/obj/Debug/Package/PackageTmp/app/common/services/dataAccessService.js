var app;
(function (app) {
    var common;
    (function (common) {
        var DataAccessService = (function () {
            function DataAccessService($resource, appSettings) {
                this.$resource = $resource;
                this.appSettings = appSettings;
            }
            //ServiceType
            DataAccessService.prototype.getServiceTypeResource = function (odataParameters) {
                var getServiceTypeListAction = { method: 'GET', isArray: false };
                var getServiceTypeByIDAction = { method: 'GET', params: { id: '@id' }, url: this.appSettings.serverPath + 'odata/ServiceTypes(:id)', isArray: false };
                var getServiceTypesByOwnerGroupAction = { method: 'GET', params: { id: '@id' }, url: this.appSettings.serverPath + 'odata/ServiceTypes?$expand=ServiceTypeOwnerGroup&$filter=(ServiceTypeOwnerGroup/ServiceTypeOwnerGroupID eq guid\':id\' and ServiceTypeShowAsStandaloneServiceFlag eq true and AdmIsActive eq \'Y\') &$select=ServiceTypeName, ServiceTypeID&$orderby=ServiceTypeName', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/ServiceTypes' + odataParameters, {}, {
                    getServiceTypeList: getServiceTypeListAction,
                    getServiceTypeByID: getServiceTypeByIDAction,
                    getServiceTypesByOwnerGroup: getServiceTypesByOwnerGroupAction
                });
            };
            //ServiceTypeOwnerGroup
            DataAccessService.prototype.getServiceTypeOwnerGroupResource = function (odataParameters) {
                var getServiceTypeOwnerListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/ServiceTypeOwnerGroups' + odataParameters, {}, {
                    getServiceTypeOwnerList: getServiceTypeOwnerListAction
                });
            };
            //Request
            DataAccessService.prototype.getRequestResource = function (odataParameters) {
                var getRequestListAction = { method: 'GET', isArray: false };
                var getRequestByIDAction = { method: 'GET', params: { id: '@id' }, url: this.appSettings.serverPath + 'odata/Requests(:id)' + odataParameters, isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/Requests' + odataParameters, {}, {
                    getRequestList: getRequestListAction,
                    getRequestByID: getRequestByIDAction
                });
            };
            //RequestTaxpayerPreferredLanguage
            DataAccessService.prototype.getRequestTaxpayerPreferredLanguageResource = function (odataParameters) {
                return this.$resource(this.appSettings.serverPath + 'odata/RequestTaxpayerPreferredLanguages' + odataParameters, {}, {});
            };
            //RequestOrigin
            DataAccessService.prototype.getRequestOriginResource = function (odataParameters) {
                var getRequestOriginListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/RequestOrigins' + odataParameters, {}, {
                    getRequestOriginList: getRequestOriginListAction
                });
            };
            //RequestPriority
            DataAccessService.prototype.getRequestPriorityResource = function (odataParameters) {
                var getRequestPriorityListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/RequestPriorities' + odataParameters, {}, {
                    getRequestPriorityList: getRequestPriorityListAction
                });
            };
            //RequestStatus
            DataAccessService.prototype.getRequestStatusResource = function (odataParameters) {
                var getRequestStatusListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/RequestStatus' + odataParameters, {}, {
                    getRequestStatusList: getRequestStatusListAction
                });
            };
            //ServiceTypeResolution
            DataAccessService.prototype.getServiceTypeResolutionResource = function (odataParameters) {
                var getServiceTypeResolutionListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/ServiceTypeResolutions' + odataParameters, {}, {
                    getServiceTypeResolutionList: getServiceTypeResolutionListAction
                });
            };
            //RequestTaxpayer
            DataAccessService.prototype.getRequestTaxpayerResource = function (odataParameters) {
                var getRequestTaxpayerListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/RequestTaxpayers' + odataParameters, {}, {
                    getRequestTaxpayerList: getRequestTaxpayerListAction
                });
            };
            //ServiceTypeCustomFieldTransaction
            DataAccessService.prototype.getServiceTypeCustomFieldTransactionResource = function (odataParameters) {
                var getServiceTypeCustomFieldTransactionListAction = { method: 'GET', isArray: false };
                return this.$resource(this.appSettings.serverPath + 'odata/ServiceTypeCustomFieldTransactions' + odataParameters, {}, {
                    getServiceTypeCustomFieldTransactionList: getServiceTypeCustomFieldTransactionListAction
                });
            };
            //RequestFolio
            DataAccessService.prototype.getRequestFolioResource = function (odataParameters) {
                return this.$resource(this.appSettings.serverPath + 'odata/RequestFolios' + odataParameters, {}, {});
            };
            //RequestActionType
            DataAccessService.prototype.getRequestActionTypeResource = function (odataParameters) {
                return this.$resource(this.appSettings.serverPath + 'odata/RequestActionTypes' + odataParameters, {}, {});
            };
            ;
            //RequestAction
            DataAccessService.prototype.getRequestActionResource = function (odataParameters) {
                return this.$resource(this.appSettings.serverPath + 'odata/RequestActions' + odataParameters, {}, {});
            };
            ;
            //NOT ODATA Controller: AssociatedServiceTypeViewModel
            DataAccessService.prototype.getAssociatedServiceTypeResource = function (controllerActionName) {
                return this.$resource(this.appSettings.serverPath + 'AssociatedServiceTypes/' + controllerActionName + ':id', {}, {});
            };
            ;
            //NOT ODATA Controller: RequestWorkspaceViewModel
            DataAccessService.prototype.getRequestWorkspaceViewModelResource = function (controllerActionName) {
                return this.$resource(this.appSettings.serverPath + 'RequestWorkspaceViewModel/' + controllerActionName + ':id', {}, {});
            };
            ;
            //NOT ODATA Controller: DashboardViewModel
            DataAccessService.prototype.getMyDashboardViewModelResource = function (controllerActionName) {
                return this.$resource(this.appSettings.serverPath + 'MyDashboard/' + controllerActionName, {}, {});
            };
            ;
            return DataAccessService;
        }());
        //static propery of the class (not instance of the class) names of services to inject must be in the same order in the constructor
        DataAccessService.$inject = ["$resource", "appSettings"];
        common.DataAccessService = DataAccessService;
        angular.module("common.services")
            .service('dataAccessService', DataAccessService);
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=dataAccessService.js.map