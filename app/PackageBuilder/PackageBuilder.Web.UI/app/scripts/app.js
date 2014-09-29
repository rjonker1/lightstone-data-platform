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
    'providerServices'
    
  ])
  .config(function ($routeProvider) {

    $routeProvider
      .when('/', {
        templateUrl: 'views/home.html'
      })
      .when('/data-source-detail', {
        templateUrl: 'views/dataSourceDetail.html',
        controller: 'dsCtrl'
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