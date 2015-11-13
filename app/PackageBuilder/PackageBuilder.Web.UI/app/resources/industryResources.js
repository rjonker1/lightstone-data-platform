'use strict';

var industryResources = angular.module('industryResources', ['ngResource', 'app']);

industryResources.factory('getIndexIndustryResource', ['$resource', 'config',
	function ($resource, config) {
	    return $resource( config.apiUri + '/Industries', {}, {
	        query: { method: 'GET', isArray: true }
	    });
	}]);

industryResources.factory('postAddIndustryResource', ['$resource', 'config',
	function ($resource, config) {
	    return $resource( config.apiUri + '/Industries', {}, {
	        save: { method: 'POST', isObject: true }
	    });
	}]);

industryResources.factory('postEditIndustryResource', ['$resource', 'config',
	function ($resource, config) {
	    return $resource( config.apiUri + '/Industries', {}, {
	        save: { method: 'PUT', isObject: true }
	    });
	}]);