'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetAPI', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/33c7af16-8b21-4701-a7b1-533234b29f75', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('PostAPI', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/AddTest', {}, {
			
		});
	}]);