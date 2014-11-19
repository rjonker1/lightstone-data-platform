(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes()); //constant as they will not change
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/packages',
                config: {
                    title: 'packages',
                    templateUrl: 'app/packages/packages.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-institution"></i> Packages'
                    }
                }
            }, {
                url: '/package-maintenance',
                config: {
                    title: 'package-maintenance',
                    templateUrl: 'app/packageMaintenance/packageMaintenanceCreate.html',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-gear"></i> Package Maintenance'
                    }
                }
            }, {
                url: '/package-maintenance-edit/:id/:version',
                config: {
                    title: 'package-maintenance-edit',
                    templateUrl: 'app/packageMaintenance/packageMaintenanceEdit.html'
                }

            }, {
                url: '/data-providers',
                config: {
                    title: 'data-providers',
                    templateUrl: 'app/dataProviders/dataProviders.html',
                    settings: {
                        nav: 4,
                        content: '<i class="fa fa-calendar"></i> Data Providers'
                    }
                }
            }, {
                url: '/data-provider-detail/:id/:version',
                config: {
                    title: 'data-provider-detail',
                    templateUrl: 'app/dataProviders/dataProviderDetail.html',
                }
            }, {
                url: '/data-provider-view/:id/:version',
                config: {
                    title: 'data-provider-view',
                    templateUrl: 'app/dataProviders/dataProviderView.html',
                }
            }, {
                url: '/industries',
                config: {
                    title: 'industries',
                    templateUrl: 'app/industries/industries.html',
                    settings: {
                        nav: 6,
                        content: '<i class="fa fa-bank"></i> Industries'
                    }
                }
            }, {
                url: '/states',
                config: {
                    title: 'states',
                    templateUrl: 'app/states/states.html',
                    settings: {
                        nav: 6,
                        content: '<i class="fa fa-edit"></i> States'
                    }
                }
            }
        ];
    }
})();