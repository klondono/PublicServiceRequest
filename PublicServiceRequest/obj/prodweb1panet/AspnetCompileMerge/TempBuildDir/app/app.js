var app;
(function (app) {
    var appMain = angular
        .module('serviceRequestApp', ['ui.router', 'common.services', 'angular.filter', 'ui.mask', 'ngAnimate', 'ui.bootstrap', 'kendo.directives', 'uiSwitch']);
    appMain.config(function ($stateProvider, $urlRouterProvider, $locationProvider, appSettings, $compileProvider) {
        //remove debug info from being displayed. Performance booster.
        $compileProvider.debugInfoEnabled(false);
        $urlRouterProvider.otherwise('/Search');
        $stateProvider
            .state('Dashboard', {
            url: '/Dashboard',
            templateUrl: appSettings.serverPath + 'app/dashboard/dashboardView.html',
            controller: 'DashboardController',
            controllerAs: 'vm'
        })
            .state('ServiceRequest', {
            url: '/ServiceRequest',
            templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestCreateView.html',
            controller: 'ServiceRequestCreateController',
            controllerAs: 'vm',
            resolve: {
                dataAccessService: 'dataAccessService',
                serviceTypeOwnerGroupListResolved: function (dataAccessService) {
                    var serviceTypeOwnerGroupResource = dataAccessService.getServiceTypeOwnerGroupResource('?$select=ServiceTypeOwnerGroupID,ServiceTypeOwnerGroupName&$orderby=ServiceTypeOwnerGroupName&$filter=(AdmIsActive eq \'Y\') and (SelectableOnRequestCreationFlag eq true)');
                    return serviceTypeOwnerGroupResource.get().$promise.catch(function (reason) {
                        console.log(reason);
                    });
                }
            }
        })
            .state('Search', {
            url: '/Search',
            templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestMainSearchView.html',
            controller: 'ServiceRequestMainSearchController',
            controllerAs: 'vm'
        })
            .state('Search_Folio', {
            url: '/Search/:Folio',
            templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestMainSearchView.html',
            controller: 'ServiceRequestMainSearchController',
            controllerAs: 'vm'
        })
            .state('Workspace', {
            url: '/Workspace/:Id',
            templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestWorkspaceView.html',
            controller: 'ServiceRequestWorkspaceController',
            controllerAs: 'vm'
        })
            .state('ServiceRequest.SearchResults', {
            url: '/SearchResults/:Criteria',
            templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestSearchResultView.html',
            controller: 'ServiceRequestSearchResultController',
            controllerAs: 'vm'
        })
            .state('ServiceRequest.RequestForm', {
            url: '/RequestForm/:Id',
            views: {
                '': {
                    templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestFormView.html',
                    controller: 'ServiceRequestFormController',
                    controllerAs: 'vm',
                    resolve: {
                        dataAccessService: 'dataAccessService',
                        serviceTypeResolved: function ($stateParams, dataAccessService) {
                            var serviceTypeResource = dataAccessService.getServiceTypeResource('');
                            return serviceTypeResource.getServiceTypeByID({ id: $stateParams.Id }).$promise.catch(function (reason) {
                                console.log(reason);
                            });
                        },
                        requestPrioritiesResolved: function (dataAccessService) {
                            var requestPriorityResource = dataAccessService.getRequestPriorityResource('');
                            return requestPriorityResource.get().$promise.catch(function (reason) {
                                console.log(reason);
                            });
                        },
                        requestTaxpayerPreferredLanguagesResolved: function (dataAccessService) {
                            var requestTaxpayerPreferredLanguagesResource = dataAccessService.getRequestTaxpayerPreferredLanguageResource('');
                            return requestTaxpayerPreferredLanguagesResource.get().$promise.catch(function (reason) {
                                console.log(reason);
                            });
                        },
                        requestResolved: function ($stateParams, dataAccessService) {
                            var requestResource = dataAccessService.getRequestResource('/InitializeRequest');
                            var serviceTypeID = $stateParams.Id;
                            return new requestResource({ ServiceTypeID: serviceTypeID }).$save().catch(function (reason) {
                                console.log(reason);
                            });
                        }
                    }
                },
                'AssociatedServices@ServiceRequest': {
                    templateUrl: appSettings.serverPath + 'app/serviceRequests/serviceRequestListView.html',
                    controller: 'ServiceRequestListController',
                    controllerAs: 'vm'
                }
            }
        });
        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});
    });
})(app || (app = {}));
//# sourceMappingURL=app.js.map