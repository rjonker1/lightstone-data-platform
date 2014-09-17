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
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/home.html',
      })
      .when('/data-source-detail', {
        templateUrl: 'views/dataSourceDetail.html',
        controller: 'dsCtrl'
      })
      .when('/data-sources', {
        templateUrl: 'views/dataSources.html',
        controller: 'dsCtrl'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
