'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetAPI', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/b5cbb97a-d086-4c5b-bd37-7e5e24085b7d', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('GetDataProviders', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('PostAPI', ['$resource', 
	function($resource) {

		return $resource('http://localhost:12257/DataProvider/Edit/:id', {}, {
			
		});
	}]);