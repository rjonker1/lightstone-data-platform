'use strict';

describe('Unit: Controllers -', function() {

	beforeEach(module('packageBuilderwebuiApp'));
	describe('dsCtrl: ', function() {

		var dsCtrl, scope;
		beforeEach(inject(function ($controller, $rootScope){

			scope = $rootScope.$new();
			dsCtrl = $controller('dsCtrl', { $scope: scope });
		}));

		it('should have dataProvs set to defined', function() {

			expect(scope.dataProvider).toBeDefined();
		});
	});

});