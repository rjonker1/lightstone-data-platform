'use strict';

var stateResources = angular.module('stateResources', ['ngResource', 'app']);

stateResources.factory('getIndexStateResource', ['$resource', 'config',
    function($resource, config) {
        return $resource( config.apiUri + '/States', {}, {
            query: { method: 'GET', isArray: true }
        });
    }]);

stateResources.factory('postAddStateResource', ['$resource', 'config',
    function ($resource, config) {
        return $resource( config.apiUri + '/States', {}, {
            save: { method: 'POST', isObject: true }
        });
    }]);

stateResources.factory('postEditStateResource', ['$resource', 'config',
    function ($resource, config) {
        return $resource( config.apiUri + '/States', {}, {
            save: { method: 'PUT', isObject: true }
        });
    }]);