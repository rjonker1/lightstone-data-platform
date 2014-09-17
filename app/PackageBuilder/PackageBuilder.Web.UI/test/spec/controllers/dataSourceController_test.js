'use strict';

describe('Controller: dsCtrl', function () {

  // load the controller's module
  beforeEach(module('packageBuilderwebuiApp'));

  var dsCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    dsCtrl = $controller('dsCtrl', {
      $scope: scope
    });
  }));

  it('should retrieve data from dev.lightstone.packagebuilder.api', function () {
    expect(scope.dataProvs.length).toBe(0);
  });
});
