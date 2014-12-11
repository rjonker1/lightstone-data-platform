///<reference path="~/Scripts/jasmine/jasmine.js"/>
///<reference path="~/Scripts/angular.js"/>
///<reference path="~/Scripts/angular-mocks.js"/>
///<reference path="~/Scripts/angular-resource.min.js"/>
///<reference path="~/Scripts/angular-animate.min.js"/>
///<reference path="~/Scripts/angular-route.min.js"/>
///<reference path="~/Scripts/angular-sanitize.min.js"/>
///<reference path="~/Scripts/ui-grid3.js"/>
///<reference path="~/Scripts/angular-ui-tree.min.js"/>
///<reference path="~/Scripts/angular-multi-select.js"/>

///<reference path="~/App/app.js"/>
///<reference path="~/App/common/common.js"/>
///<reference path="~/App/common/bootstrap/bootstrap.dialog.js"/>
///<reference path="~/Scripts/ui-bootstrap-tpls-0.10.0.min.js"/>
///<reference path="~/App/services/apiProviders.js"/>
///<reference path="~/App/resources/industryResources.js"/>
///<reference path="~/App/resources/stateResources.js"/>

///<reference path="~/App/dataProviders/dataProviderDetail.js"/>

describe("DataProviders", function () {

    var scope, datacontext, $location, common;

    //Mock restService to simulate hitting an endpoint - required
    //Will need to provide $q to simulate $http promises - $q is not a provider!
    //Used a mock due to the fact that spy's are not meant to be used for complex scenarios



    beforeEach(function () {
        var mockRestService = {};
        var mockRestServiceCommon = {};

        //Ensure that the module for the controller is loaded!!
        //beforeEach(module('app'));

        //Module for the Service
        module('app', function ($provide) {
            $provide.value('datacontext', mockRestService);
        });

        module('common', function ($provide) {
            $provide.value('common', mockRestServiceCommon);
        });

        inject(function ($q) {
            mockRestService.data = [
              {
                  id: 0,
                  name: 'Angular'
              },
              {
                  id: 1,
                  name: 'Ember'
              },
              {
                  id: 2,
                  name: 'Backbone'
              },
              {
                  id: 3,
                  name: 'React'
              }
            ];

            mockRestServiceCommon.data = [{ success: true }];

            //Mock service methid name needs to match that of the defined service methods
            mockRestService.getDataProvider = function (id, version) {
                var defer = $q.defer();

                defer.resolve(this.data);

                return defer.promise;
            };


            mockRestServiceCommon.activateController = function (params, controllerId) {
                var defer = $q.defer();

                defer.resolve(this.data);

                return defer.promise;
            };

            mockRestServiceCommon.logger = function () {

            };

        });
    });

    //Load dependencies and set up the controller for the test
    beforeEach(inject(function ($controller, $rootScope, _$location_, _common_, _datacontext_) {
        scope = $rootScope.$new();
        $location = _$location_;
        common = _common_;
        datacontext = _datacontext_;
    }));


    //Instantaite the controller
    beforeEach(inject(function ($controller, $rootScope, _$location_, _common_, _datacontext_) {
        scope = $rootScope.$new();
        $location = _$location_;
        common = _common_;
        datacontext = _datacontext_;

        $controller('dataProviderDetail',
                      { $scope: scope, $location: $location, common: common, datacontext: datacontext });

        scope.$digest(); // $digest to resolce all promises setup on the mock service
    }));

    //Specs
    it('should set activateController to true', function () {
        expect(scope.status).toEqual([
          {
              success: true,
          }
        ]);
    });

});