'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetAPI', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/c581b2a4-6dc3-4f90-a4c4-f89087719447', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('PostAPI', ['$resource', 
	function($resource) {

		return $resource('http://localhost:12257/DataProvider/Add', {}, {
			
		});
	}]);