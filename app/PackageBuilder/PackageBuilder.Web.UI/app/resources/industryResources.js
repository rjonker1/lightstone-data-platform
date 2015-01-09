'use strict';

var industryResources = angular.module('industryResources', ['ngResource']);

industryResources.factory('getIndexIndustryResource', ['$resource',
	function ($resource) {
	    return $resource('http://dev.lightstone.packagebuilder.api/Industries', {}, {
	        query: { method: 'GET', isArray: true }
	    });
	}]);

industryResources.factory('postAddIndustryResource', ['$resource',
	function ($resource) {
	    return $resource('http://dev.lightstone.packagebuilder.api/Industries', {}, {
	        save: { method: 'POST', isObject: true }
	    });
	}]);

industryResources.factory('postEditIndustryResource', ['$resource',
	function ($resource) {
	    return $resource('http://dev.lightstone.packagebuilder.api/Industries', {}, {
	        save: { method: 'PUT', isObject: true }
	    });
	}]);