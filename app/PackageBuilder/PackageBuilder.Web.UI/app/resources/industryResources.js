'use strict';

var industryResources = angular.module('industryResources', ['ngResource']);

industryResources.factory('getIndexIndustryResource', ['$resource',
	function ($resource) {
	    return $resource('http://localhost:12257/Industry', {}, {
	        query: { method: 'GET', isArray: true }
	    });
	}]);

industryResources.factory('postAddIndustryResource', ['$resource',
	function ($resource) {
	    return $resource('http://localhost:12257/Industry/Add', {}, {
	        save: { method: 'POST', isObject: true }
	    });
	}]);

industryResources.factory('postEditIndustryResource', ['$resource',
	function ($resource) {
	    return $resource('http://localhost:12257/Industry/Edit', { }, {
	        save: { method: 'POST', isObject: true }
	    });
	}]);