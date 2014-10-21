'use strict';

var ApiProviderServices = angular.module('apiProviderServices', ['ngResource']);

ApiProviderServices.factory('GetDataProvider', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/:id/:version', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

ApiProviderServices.factory('GetDataProviders', ['$resource',
	function($resource) {
	    return $resource('http://dev.lightstone.packagebuilder.api/DataProvider', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

ApiProviderServices.factory('GetDataProviderSources', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/All', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

ApiProviderServices.factory('GetPackages', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/Packages', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

ApiProviderServices.factory('PostDataProvider', ['$resource',
	function($resource) {

		return $resource('http://localhost:12257/DataProvider/Edit/:id', {}, {
			
		});
	}]);

ApiProviderServices.factory('PostPackage', ['$resource',
	function($resource) {

		return $resource('http://localhost:12257/Package/Add', {}, {
			
		});
	}]);