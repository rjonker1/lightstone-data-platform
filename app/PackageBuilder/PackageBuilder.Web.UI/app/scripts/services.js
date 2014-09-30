'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetAPI', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/8f1ae13e-5122-4128-99a1-8a25769945d8', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('PostAPI', ['$resource', 
	function($resource) {

		return $resource('http://localhost:12257/DataProvider/Add', {}, {
			
		});
	}]);