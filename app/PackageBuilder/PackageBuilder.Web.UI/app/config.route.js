﻿(function () {
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
                url: '/admin',
                config: {
                    title: 'admin',
                    templateUrl: 'app/admin/admin.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/package-maintenance',
                config: {
                    title: 'package-maintenance',
                    templateUrl: 'app/packageMaintenance/packageMaintenance.html',
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-gear"></i> Package Maintenance'
                    }
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
            }
        ];
    }
})();