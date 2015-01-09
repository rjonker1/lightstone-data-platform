'use strict';

var stateResources = angular.module('stateResources', ['ngResource']);

stateResources.factory('getIndexStateResource', ['$resource',
    function($resource) {
        return $resource('http://dev.lightstone.packagebuilder.api/States', {}, {
            query: { method: 'GET', isArray: true }
        });
    }]);

stateResources.factory('postAddStateResource', ['$resource',
    function($resource) {
        return $resource('http://dev.lightstone.packagebuilder.api/States', {}, {
            save: { method: 'POST', isObject: true }
        });
    }]);

stateResources.factory('postEditStateResource', ['$resource',
    function($resource) {
        return $resource('http://dev.lightstone.packagebuilder.api/States', {}, {
            save: { method: 'PUT', isObject: true }
        });
    }]);