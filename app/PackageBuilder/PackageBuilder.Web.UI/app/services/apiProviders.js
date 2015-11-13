'use strict';

var ApiProviderServices = angular.module('apiProviderServices', ['ngResource']);

ApiProviderServices.factory('GetDataProvider', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/Get/:id/:version', {}, {
			query: { method:'GET', isObject:true}
		});
	}]);

ApiProviderServices.factory('GetDataProviders', ['$resource',
	function($resource) {
	    return $resource('http://dev.lightstone.packagebuilder.api/DataProvider', {}, {
			query: { method: 'GET', isArray:true }
		});
	}]);

ApiProviderServices.factory('GetDataProviderSources', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/Get/All', {}, {
		    query: { method: 'GET', isObject:true }
		});
	}]);

ApiProviderServices.factory('GetPackages', ['$resource',
	function($resource) {
		return $resource('http://dev.lightstone.packagebuilder.api/Packages', {}, {
			query: { method: 'GET', isArray:true }
		});
	}]);

ApiProviderServices.factory('PostDataProvider', ['$resource',
	function($resource) {

	    return $resource('http://dev.lightstone.packagebuilder.api/DataProvider/Edit/:id', {}, {
			
		});
	}]);

ApiProviderServices.factory('PostPackage', ['$resource',
	function($resource) {

	    return $resource('http://dev.lightstone.packagebuilder.api/Package/Add', {}, {
			
		});
	}]);