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

///<reference path="~/App/dataProviders/dataProviders.js"/>
///<reference path="~/Scripts/linq.js"/>

describe('Controller: dataProviders', function () {

    var scope, datacontext, $location, common;

    //Mock restService to simulate hitting an endpoint - required
    //Will need to provide $q to simulate $http promises - $q is not a provider!
    //Used a mock due to the fact that spy's are not meant to be used for complex scenarios

    beforeEach(function () {
        var datacontextServiceMock = {};
        var commonServiceMock = {};

        //Ensure that the module for the controller is loaded!!
        //beforeEach(module('app'));

        //Module for the Service
        module('app', function ($provide) {
            $provide.value('datacontext', datacontextServiceMock);
        });

        module('common', function ($provide) {
            $provide.value('common', commonServiceMock);
        });

        inject(function($q) {

            //Mock data
            commonServiceMock.data = [{ success: true }];

            datacontextServiceMock.data = [{ id: 001, name: 'DataProvider1' }];
            
            
            //Mock Services
            //Mock service method name needs to match that of the defined service methods

            //common
            commonServiceMock.activateController = function (params, controllerId) {
                var defer = $q.defer();

                defer.resolve(this.data);

                return defer.promise;
            };

            commonServiceMock.logger = function () {

            };

            commonServiceMock.logger.getLogFn = function (controllerId) {
                return function logFn(parameters) {

                }
            };

            //datacontext
            datacontextServiceMock.getAllDataProviders = function (id, version) {
                var defer = $q.defer();

                defer.resolve(this.data);

                //Inject the promise into the expected .then(response), to define response
                return defer.promise;
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

        $controller('dataProviders',
                      { $scope: scope, $location: $location, common: common, datacontext: datacontext });

        scope.$digest(); // $digest to resolve all promises setup on the mock service
    }));

    //Specs
    it('should set the title to: "Data Providers"', function () {
        expect(scope.title).toEqual('Data Providers');
    });

    it('should get a list of Data Providers', function () {
        expect(scope.dProvidersData.length).toBeGreaterThan(0);
    });

    it('should initialize the GridView with populated Data Providers', function () {
        expect(scope.gridOptions).not.toBeNull();
    });


    describe('Routing:',function() {

        it('should redirect to a Data Provider View page', function () {
            spyOn($location, 'path');

            var row = {
                entity: {
                    dataProviderId: "cab7ff2c-1358-4a99-9da1-1d0b5b26c31b",
                    version: 1
                }
            }

            // We simulate we clicked a library on the page
            scope.viewDataProvider(row);

            expect($location.path).toHaveBeenCalledWith('/data-provider-view/cab7ff2c-1358-4a99-9da1-1d0b5b26c31b/1');
        });

        it('should redirect to a Data Provider Edit page', function () {
            spyOn($location, 'path');

            var row = {
                entity: {
                    dataProviderId: "cab7ff2c-1358-4a99-9da1-1d0b5b26c31b",
                    version: 1
                }
            }

            // We simulate we clicked a library on the page
            scope.notify(row);

            expect($location.path).toHaveBeenCalledWith('/data-provider-detail/cab7ff2c-1358-4a99-9da1-1d0b5b26c31b/1');
        });

    });

});