'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetDataProvider', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/:id/:version', {}, {
			query: {method:'GET', isObject:true}
		});
	}]);

providerServices.factory('GetDataProviders', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('GetDataProviderSources', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/DataProvider/Get/All', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('GetPackages', ['$resource',
	function($resource) {
		return $resource('http://localhost:12257/Packages', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('PostDataProvider', ['$resource', 
	function($resource) {

		return $resource('http://localhost:12257/DataProvider/Edit/:id', {}, {
			
		});
	}]);

providerServices.factory('PostPackage', ['$resource', 
	function($resource) {

		return $resource('http://localhost:12257/Package/Add', {}, {
			
		});
	}]);