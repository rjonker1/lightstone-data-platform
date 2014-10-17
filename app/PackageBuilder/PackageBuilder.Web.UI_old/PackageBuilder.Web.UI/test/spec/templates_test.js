'use strict';

describe('Unit: Templates -', function() {

	var location, 
		route, 
		rootScope, 
		$httpBackend;

	beforeEach(module('packageBuilderwebuiApp'));
	beforeEach(inject(function (_$location_, _$route_, _$rootScope_, _$httpBackend_) {

		location = _$location_;
		route = _$route_;
		rootScope = _$rootScope_;
		$httpBackend = _$httpBackend_;
	}));

	afterEach(function() {

		$httpBackend.verifyNoOutstandingExpectation();
		$httpBackend.verifyNoOutstandingRequest();
	});

	it('loads the home template at /', function() {

		$httpBackend.expectGET('views/home.html')
		.respond(200);

		location.path('/');
		rootScope.$digest();
		$httpBackend.flush();

	});

	it('loads the home template at /data-source-detail', function() {

		$httpBackend.expectGET('views/dataSourceDetail.html')
		.respond(200);

		location.path('/data-source-detail');
		rootScope.$digest();
		$httpBackend.flush();

	});

	it('loads the home template at /data-sources', function() {

		$httpBackend.expectGET('views/dataSources.html')
		.respond(200);

		location.path('/data-sources');
		rootScope.$digest();
		$httpBackend.flush();

	});

	it('loads the home template at /package-detail', function() {

		$httpBackend.expectGET('views/packageDetail.html')
		.respond(200);

		location.path('/package-detail');
		rootScope.$digest();
		$httpBackend.flush();

	});

});
