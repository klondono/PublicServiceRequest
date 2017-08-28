module app.common {
    //custom http verbs can include the following parameters: customhttpVerb(params?: Object, success?: Function, error?: Function)
    //refer to angular typings file for more info
    //ServiceType
    export interface IServiceTypeResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IServiceType>> {
        //extend IResourceClass with custom http verbs
        getServiceTypeList(IServiceTypeSuccess : Function): ng.resource.IResource<app.domain.IServiceType>;
        getServiceTypeByID(params: Object): ng.resource.IResource<app.domain.IServiceType>;
        getServiceTypesByOwnerGroup(params: Object, IServiceTypeSuccess: Function): ng.resource.IResource<app.domain.IServiceType>;
    }

    //ServiceTypeOwnerGroup
    export interface IServiceTypeOwnerGroupResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IServiceTypeOwnerGroup>> {
        //extend IResourceClass with custom http verbs
        getServiceTypeOwnerList(IServiceTypeOwnerGroupSuccess: Function): ng.resource.IResource<app.domain.IServiceTypeOwnerGroup>;
    }

    //Request
    export interface IRequestResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequest>> {
        //extend IResourceClass with custom http verbs
        getRequestList(IRequestSuccess: Function): ng.resource.IResource<app.domain.IRequest>;
        getRequestByID(params: Object, IRequestSuccess: Function, IRequestError: Function): ng.resource.IResource<app.domain.IRequest>;
    }

    //RequestTaxpayerPreferredLanguage
    export interface IRequestTaxpayerPreferredLanguageResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestTaxpayerPreferredLanguage>> {
        //extend IResourceClass with custom http verbs
    }

    //RequestOrigin
    export interface IRequestOriginResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestOrigin>> {
        //extend IResourceClass with custom http verbs
        getRequestOriginList(IRequestOriginSuccess: Function): ng.resource.IResource<app.domain.IRequestOrigin>;
    }

    //RequestPriority
    export interface IRequestPriorityResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestPriority>> {
        //extend IResourceClass with custom http verbs
        getRequestPriorityList(IRequestPrioritySuccess: Function): ng.resource.IResource<app.domain.IRequestPriority>;
    }

    //RequestStatus
    export interface IRequestStatusResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestStatus>> {
        //extend IResourceClass with custom http verbs
        getRequestStatusList(IRequestStatusSuccess : Function): ng.resource.IResource<app.domain.IRequestStatus>;
    }

    //ServiceTypeResolution
    export interface IServiceTypeResolutionResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IServiceTypeResolution>> {
        //extend IResourceClass with custom http verbs
        getServiceTypeResolutionList(IServiceTypeResolutionSuccess: Function): ng.resource.IResource<app.domain.IServiceTypeResolution>;
    }

    //RequestTaxpayer
    export interface IRequestTaxpayerResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestTaxpayer>> {
        //extend IResourceClass with custom http verbs
        getRequestTaxpayerList(IServiceTypeOwnerGroupSuccess: Function): ng.resource.IResource<app.domain.IRequestTaxpayer>;
    }

    //ServiceTypeCustomFieldTransaction
    export interface IServiceTypeCustomFieldTransactionResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IServiceTypeCustomFieldTransaction>> {
        //extend IResourceClass with custom http verbs
        getServiceTypeCustomFieldTransactionList(IServiceTypeCustomFieldTransactionSuccess: Function): ng.resource.IResource<app.domain.IServiceTypeCustomFieldTransaction>;
    }

    //RequestFolio
    export interface IRequestFolioResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestFolio>> {
        //extend IResourceClass with custom http verbs
    }

    //RequestAction
    export interface IRequestActionResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestAction>> {
        //extend IResourceClass with custom http verbs
    }

    //RequestActionType
    export interface IRequestActionTypeResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestActionType>> {
        //extend IResourceClass with custom http verbs
    }

    //RequestActionType
    export interface IRequestActionTypeResource extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestActionType>> {
        //extend IResourceClass with custom http verbs
    }

    //NOT ODATA Controller: AssociatedServiceTypeViewModel
    export interface IAssociatedServiceTypeViewModel extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IAssociatedServiceTypeViewModel>> {
        //extend IResourceClass with custom http verbs
    }

    //NOT ODATA Controller: RequestWorkspaceViewModel
    export interface IRequestWorkspaceViewModel extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IRequestWorkspaceViewModel>> {
    //extend IResourceClass with custom http verbs
    }

    //NOT ODATA Controller: DashboardViewModel
    export interface IMyDashboardViewModel extends ng.resource.IResourceClass<ng.resource.IResource<app.domain.IMyDashboardViewModel>> {
        //extend IResourceClass with custom http verbs
    }

    interface IDataAccessService {
        //ServiceType
        getServiceTypeResource(odataParameters: string): IServiceTypeResource;

        //ServiceTypeOwnerGroup
        getServiceTypeOwnerGroupResource(odataParameters: string): IServiceTypeOwnerGroupResource;

        //Request
        getRequestResource(odataParameters: string): IRequestResource;

        //RequestTaxpayerPreferredLanguage
        getRequestTaxpayerPreferredLanguageResource(odataParameters: string): IRequestTaxpayerPreferredLanguageResource;

        //RequestOrigin
        getRequestOriginResource(odataParameters: string): IRequestOriginResource;

        //RequestPriority
        getRequestPriorityResource(odataParameters: string): IRequestPriorityResource;

        //RequestStatus
        getRequestStatusResource(odataParameters: string): IRequestStatusResource;

        //ServiceTypeResolution
        getServiceTypeResolutionResource(odataParameters: string): IServiceTypeResolutionResource;

        //RequestTaxpayer
        getRequestTaxpayerResource(odataParameters: string): IRequestTaxpayerResource;

        //ServiceTypeCustomFieldTransaction
        getServiceTypeCustomFieldTransactionResource(odataParameters: string): IServiceTypeCustomFieldTransactionResource;

        //RequestActionType
        getRequestActionTypeResource(odataParameters: string): IRequestActionTypeResource;

        //RequestAction
        getRequestActionResource(odataParameters: string): IRequestActionResource;

        //NOT ODATA Controller: AssociatedServiceTypeViewModel
        getAssociatedServiceTypeResource(controllerActionName: string): IAssociatedServiceTypeViewModel

        //NOT ODATA Controller: DashboardViewModel
        getMyDashboardViewModelResource(controllerActionName: string): IMyDashboardViewModel
    }

    export class DataAccessService
        implements IDataAccessService {

        //static propery of the class (not instance of the class) names of services to inject must be in the same order in the constructor
        static $inject = ["$resource", "appSettings"];

        constructor(private $resource: ng.resource.IResourceService, private appSettings: app.common.IAppSettings) {}

        //ServiceType
        getServiceTypeResource(odataParameters: string): IServiceTypeResource {

            var getServiceTypeListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            var getServiceTypeByIDAction: ng.resource.IActionDescriptor = { method: 'GET', params: { id: '@id' }, url: this.appSettings.serverPath + 'odata/ServiceTypes(:id)', isArray: false };
            var getServiceTypesByOwnerGroupAction: ng.resource.IActionDescriptor = { method: 'GET', params: { id: '@id' }, url: this.appSettings.serverPath + 'odata/ServiceTypes?$expand=ServiceTypeOwnerGroup&$filter=(ServiceTypeOwnerGroup/ServiceTypeOwnerGroupID eq guid\':id\' and ServiceTypeShowAsStandaloneServiceFlag eq true and AdmIsActive eq \'Y\') &$select=ServiceTypeName, ServiceTypeID&$orderby=ServiceTypeName', isArray: false };

            return <IServiceTypeResource>this.$resource(this.appSettings.serverPath + 'odata/ServiceTypes' + odataParameters, {}, {
                getServiceTypeList: getServiceTypeListAction,
                getServiceTypeByID: getServiceTypeByIDAction,
                getServiceTypesByOwnerGroup: getServiceTypesByOwnerGroupAction

            });
        }
        //ServiceTypeOwnerGroup
        getServiceTypeOwnerGroupResource(odataParameters: string): IServiceTypeOwnerGroupResource {
            var getServiceTypeOwnerListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            
            
            return <IServiceTypeOwnerGroupResource>this.$resource(this.appSettings.serverPath + 'odata/ServiceTypeOwnerGroups' + odataParameters, {}, {
                getServiceTypeOwnerList: getServiceTypeOwnerListAction
            });
        }

        //Request
        getRequestResource(odataParameters: string): IRequestResource {
            var getRequestListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            var getRequestByIDAction: ng.resource.IActionDescriptor = { method: 'GET', params: { id: '@id' }, url: this.appSettings.serverPath + 'odata/Requests(:id)'+odataParameters, isArray: false };
            return <IRequestResource>this.$resource(this.appSettings.serverPath + 'odata/Requests' + odataParameters, {}, {
                getRequestList: getRequestListAction,
                getRequestByID: getRequestByIDAction
            });
        }

        //RequestTaxpayerPreferredLanguage
        getRequestTaxpayerPreferredLanguageResource(odataParameters: string): IRequestTaxpayerPreferredLanguageResource {
            return <IRequestTaxpayerPreferredLanguageResource>this.$resource(this.appSettings.serverPath + 'odata/RequestTaxpayerPreferredLanguages' + odataParameters, {}, {});
        }

        //RequestOrigin
        getRequestOriginResource(odataParameters: string): IRequestOriginResource {
            var getRequestOriginListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            return <IRequestOriginResource>this.$resource(this.appSettings.serverPath + 'odata/RequestOrigins' + odataParameters, {}, {
                getRequestOriginList: getRequestOriginListAction
            });
        }

        //RequestPriority
        getRequestPriorityResource(odataParameters: string): IRequestPriorityResource {
            var getRequestPriorityListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            return <IRequestPriorityResource>this.$resource(this.appSettings.serverPath + 'odata/RequestPriorities' + odataParameters, {}, {
                getRequestPriorityList: getRequestPriorityListAction
            });
        }

        //RequestStatus
        getRequestStatusResource(odataParameters: string): IRequestStatusResource {
            var getRequestStatusListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            return <IRequestStatusResource>this.$resource(this.appSettings.serverPath + 'odata/RequestStatus' + odataParameters, {}, {
                getRequestStatusList: getRequestStatusListAction
            });
        }

        //ServiceTypeResolution
        getServiceTypeResolutionResource(odataParameters: string): IServiceTypeResolutionResource {
            var getServiceTypeResolutionListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            return <IServiceTypeResolutionResource>this.$resource(this.appSettings.serverPath + 'odata/ServiceTypeResolutions' + odataParameters, {}, {
                getServiceTypeResolutionList: getServiceTypeResolutionListAction
            });
        }

        //RequestTaxpayer
        getRequestTaxpayerResource(odataParameters: string): IRequestTaxpayerResource {
            var getRequestTaxpayerListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            return <IRequestTaxpayerResource>this.$resource(this.appSettings.serverPath + 'odata/RequestTaxpayers' + odataParameters, {}, {
                getRequestTaxpayerList: getRequestTaxpayerListAction
            });
        }

        //ServiceTypeCustomFieldTransaction
        getServiceTypeCustomFieldTransactionResource(odataParameters: string): IServiceTypeCustomFieldTransactionResource {
            var getServiceTypeCustomFieldTransactionListAction: ng.resource.IActionDescriptor = { method: 'GET', isArray: false };
            return <IServiceTypeCustomFieldTransactionResource>this.$resource(this.appSettings.serverPath + 'odata/ServiceTypeCustomFieldTransactions' + odataParameters, {}, {
                getServiceTypeCustomFieldTransactionList: getServiceTypeCustomFieldTransactionListAction
            });
        }

        //RequestFolio
        getRequestFolioResource(odataParameters: string): IRequestFolioResource {
            return <IRequestFolioResource>this.$resource(this.appSettings.serverPath + 'odata/RequestFolios' + odataParameters, {}, {});
        }

        //RequestActionType
        getRequestActionTypeResource(odataParameters: string): IRequestActionTypeResource {
            return <IRequestActionTypeResource>this.$resource(this.appSettings.serverPath + 'odata/RequestActionTypes' + odataParameters, {}, {});

        };

        //RequestAction
        getRequestActionResource(odataParameters: string): IRequestActionResource {
            return <IRequestActionResource>this.$resource(this.appSettings.serverPath + 'odata/RequestActions' + odataParameters, {}, {});
        };

        //NOT ODATA Controller: AssociatedServiceTypeViewModel
        getAssociatedServiceTypeResource(controllerActionName: string): IAssociatedServiceTypeViewModel {
            return <IAssociatedServiceTypeViewModel>this.$resource(this.appSettings.serverPath + 'AssociatedServiceTypes/' + controllerActionName + ':id', {},{});
        };

        //NOT ODATA Controller: RequestWorkspaceViewModel
        getRequestWorkspaceViewModelResource(controllerActionName: string): IRequestWorkspaceViewModel {
            return <IRequestWorkspaceViewModel>this.$resource(this.appSettings.serverPath + 'RequestWorkspaceViewModel/' + controllerActionName + ':id', {}, {});
        };

        //NOT ODATA Controller: DashboardViewModel
        getMyDashboardViewModelResource(controllerActionName: string): IMyDashboardViewModel {
            return <IMyDashboardViewModel>this.$resource(this.appSettings.serverPath + 'MyDashboard/' + controllerActionName, {}, {});
        };
    }
    angular.module("common.services")
        .service('dataAccessService', DataAccessService)
}
