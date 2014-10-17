'use strict';

describe('Unit: Route test -', function() {

	//Mock the module
	beforeEach(module('packageBuilderwebuiApp'));

	var location, 
		route, 
		rootScope, 
		$httpBackend;

	beforeEach(inject(function (_$location_, _$route_, _$rootScope_, _$httpBackend_) {
		location = _$location_;
		route = _$route_;
		rootScope = _$rootScope_;
		$httpBackend = _$httpBackend_;
	}));

	//Test Code
	describe('dataSourceDetail route:', function() {


		it('should load the index page on successful load of /data-source-detail',

		function() {

			$httpBackend.expectGET('views/dataSourceDetail.html')
					.respond(200, 'dataSourceDetail HTML');

			location.path('/data-source-detail');
			rootScope.$digest(); // digest loop
			expect(route.current.controller).toBe('dsCtrl');
		});		

	});


	describe('packageDetail route: ', function() {


		it('should load the index page on successful load of /package-detail',

		function() {

			$httpBackend.expectGET('views/packageDetail.html')
					.respond(200, 'packageDetail HTML');

			location.path('/package-detail');
			rootScope.$digest(); // digest loop
			expect(route.current.controller).toBe('pkgCtrl');
		});
	});

});