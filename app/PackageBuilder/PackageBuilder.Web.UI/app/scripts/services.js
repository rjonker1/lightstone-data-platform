'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetAPI', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/Get/9144c076-2e85-4954-8e01-cee3108621b9', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('PostAPI', ['$resource', 
	function($resource) {

		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/AddTest', {}, {
			
		});
	}]);