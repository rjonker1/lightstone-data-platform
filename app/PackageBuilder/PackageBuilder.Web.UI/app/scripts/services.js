'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetAPI', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/:id/:version', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('GetDataProviders', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('GetDataProviderSources', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/DataSources', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('PostAPI', ['$resource', 
	function($resource) {

		return $resource('http://localhost:12257/DataProvider/Edit/:id', {}, {
			
		});
	}]);