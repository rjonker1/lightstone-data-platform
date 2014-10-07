'use strict';

/**
 * @ngdoc overview
 * @name packageBuilderwebuiApp
 * @description
 * # packageBuilderwebuiApp
 *
 * Main module of the application.
 */
angular
  .module('packageBuilderwebuiApp', [
    'ngAnimate',
    'ngCookies',
    'ngRoute',
    'ngSanitize',    
    'ngTouch',
    'ui.tree',
    'ui.bootstrap',
    'ngGrid',
    'providerServices'
    
  ])
  .config(function ($routeProvider) {

    $routeProvider
      .when('/', {
        templateUrl: 'views/home.html'
      })
      .when('/data-source-detail/:id/:version', {
        templateUrl: 'views/dataSourceDetail.html',
        controller: 'dsDetailCtrl'
      })
      .when('/data-sources', {
        templateUrl: 'views/dataSources.html',
        controller: 'dsCtrl'
      })
      .when('/package-detail', {
        templateUrl: 'views/packageDetail.html',
        controller: 'pkgCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  })