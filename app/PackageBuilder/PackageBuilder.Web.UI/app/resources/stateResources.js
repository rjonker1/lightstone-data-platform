'use strict';

var stateResources = angular.module('stateResources', ['ngResource']);

stateResources.factory('getIndexStateResource', ['$resource',
    function($resource) {
        return $resource('http://dev.lightstone.packagebuilder.api/State', {}, {
            query: { method: 'GET', isArray: true }
        });
    }]);

stateResources.factory('postAddStateResource', ['$resource',
    function($resource) {
        return $resource('http://dev.lightstone.packagebuilder.api/State/Add', {}, {
            save: { method: 'POST', isObject: true }
        });
    }]);

stateResources.factory('postEditStateResource', ['$resource',
    function($resource) {
        return $resource('http://dev.lightstone.packagebuilder.api/State/Edit', {}, {
            save: { method: 'POST', isObject: true }
        });
    }]);