///<reference path="~/Scripts/jasmine/jasmine.js"/>
///<reference path="~/Scripts/angular.js"/>
///<reference path="~/Scripts/angular-mocks.js"/>

///<reference path="~/App/app.js"/>
///<reference path="~/App/dataProviders/dataProviderDetail.js"/>

describe("DataProviders", function () {

    beforeEach(module("common"));
    beforeEach(module("app"));

    describe("DataProviderDetail", function () {

        var scope,
            controller;

        var datacontextMock;

        beforeEach(angular.mock.inject(function ($injector) {

            datacontextMock = jasmine.createSpyObj('datacontext', ['getDataProvider', 'getIndustries']);

            //module('app');

            inject(function ($rootScope, $controller, $location, $routeParams, $q) {

                scope = $rootScope.$new();
                _location = $location;
                _routeParams = $routeParams;
                _common = $injector.get('common');
                //_datacontext = $injector.get('datacontext');


                datacontextMock.getDataProvider.andReturn($q.when('test'));
                datacontextMock.getIndustries.andReturn($q.when('test2'));

                controller = $controller('dataProviderDetail', {
                    $scope: scope,
                    $location: _location,
                    $routeParams: _routeParams,
                    common: _common,
                    //datacontext: datacontext
                    datacontext: datacontextMock
                });

            });

        }));

        //Spec 1
        it('should resolve title', function () {
            expect(scope.title).toBe('Data Provider Detail');
        });

    });
});