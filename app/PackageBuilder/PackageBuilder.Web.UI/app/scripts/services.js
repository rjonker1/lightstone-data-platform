'use strict';

var providerServices = angular.module('providerServices', ['ngResource']);

providerServices.factory('GetDataProvider', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/Get/:id/:version', {}, {
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

providerServices.factory('GetPackages', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/Packages', {}, {
			query: { method: 'GET', isObject:true }
		});
	}]);

providerServices.factory('PostDataProvider', ['$resource', 
	function($resource) {

		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/Edit/:id', {}, {
			
		});
	}]);

providerServices.factory('PostPackage', ['$resource', 
	function($resource) {

		return $resource('http://dev.lightstone.packagebuilder.api/Package/Add', {}, {
			
		});
	}]);