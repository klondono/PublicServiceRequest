module app.dashboard {
    interface IDashboardModel {
    }
    class DashboardController implements IDashboardModel {
        //declare properties for class

        //inject dependencies, must be in same order as in the constructor
        //static $inject = ['dataAccessService'];

        constructor(private dataAccessService: app.common.DataAccessService) {

        }

    }
    angular.module('serviceRequestApp')
        .controller('DashboardController', DashboardController);
}